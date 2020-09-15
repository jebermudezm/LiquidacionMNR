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
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblUsuario>>> GetTblUsuario()
        {
            return await _context.TblUsuario.ToListAsync();
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblUsuario>> GetTblUsuario(int id)
        {
            var tblUsuario = await _context.TblUsuario.FindAsync(id);

            if (tblUsuario == null)
            {
                return NotFound();
            }

            return tblUsuario;
        }

        // PUT: api/Usuario/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblUsuario(int id, TblUsuario tblUsuario)
        {
            if (id != tblUsuario.IdUsuario)
            {
                return BadRequest();
            }

            _context.Entry(tblUsuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblUsuarioExists(id))
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

        // POST: api/Usuario
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblUsuario>> PostTblUsuario(TblUsuario tblUsuario)
        {
            _context.TblUsuario.Add(tblUsuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblUsuario", new { id = tblUsuario.IdUsuario }, tblUsuario);
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblUsuario>> DeleteTblUsuario(int id)
        {
            var tblUsuario = await _context.TblUsuario.FindAsync(id);
            if (tblUsuario == null)
            {
                return NotFound();
            }

            _context.TblUsuario.Remove(tblUsuario);
            await _context.SaveChangesAsync();

            return tblUsuario;
        }

        private bool TblUsuarioExists(int id)
        {
            return _context.TblUsuario.Any(e => e.IdUsuario == id);
        }
    }
}
