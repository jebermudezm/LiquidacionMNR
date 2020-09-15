using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lbum.Data.Models;

namespace Lbum.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PerfilController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Perfil
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblPerfil>>> GetTblPerfil()
        {
            return await _context.TblPerfil.ToListAsync();
        }

        // GET: api/Perfil/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblPerfil>> GetTblPerfil(int id)
        {
            var tblPerfil = await _context.TblPerfil.FindAsync(id);

            if (tblPerfil == null)
            {
                return NotFound();
            }

            return tblPerfil;
        }

        // PUT: api/Perfil/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblPerfil(int id, TblPerfil tblPerfil)
        {
            if (id != tblPerfil.IdPerfil)
            {
                return BadRequest();
            }

            _context.Entry(tblPerfil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPerfilExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Perfil
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblPerfil>> PostTblPerfil(TblPerfil tblPerfil)
        {
            _context.TblPerfil.Add(tblPerfil);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblPerfil", new { id = tblPerfil.IdPerfil }, tblPerfil);
        }

        // DELETE: api/Perfil/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblPerfil>> DeleteTblPerfil(int id)
        {
            var tblPerfil = await _context.TblPerfil.FindAsync(id);
            if (tblPerfil == null)
            {
                return NotFound();
            }

            _context.TblPerfil.Remove(tblPerfil);
            await _context.SaveChangesAsync();

            return tblPerfil;
        }

        private bool TblPerfilExists(int id)
        {
            return _context.TblPerfil.Any(e => e.IdPerfil == id);
        }
    }
}
