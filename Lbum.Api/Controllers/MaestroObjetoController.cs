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
    public class MaestroObjetoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MaestroObjetoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/MaestroObjeto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblMaestroObjeto>>> GetTblMaestroObjeto()
        {
            return await _context.TblMaestroObjeto.ToListAsync();
        }

        // GET: api/MaestroObjeto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblMaestroObjeto>> GetTblMaestroObjeto(int id)
        {
            var tblMaestroObjeto = await _context.TblMaestroObjeto.FindAsync(id);

            if (tblMaestroObjeto == null)
            {
                return NotFound();
            }

            return tblMaestroObjeto;
        }

        // PUT: api/MaestroObjeto/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblMaestroObjeto(int id, TblMaestroObjeto tblMaestroObjeto)
        {
            if (id != tblMaestroObjeto.IdMaestroObjeto)
            {
                return BadRequest();
            }

            _context.Entry(tblMaestroObjeto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblMaestroObjetoExists(id))
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

        // POST: api/MaestroObjeto
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblMaestroObjeto>> PostTblMaestroObjeto(TblMaestroObjeto tblMaestroObjeto)
        {
            _context.TblMaestroObjeto.Add(tblMaestroObjeto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblMaestroObjeto", new { id = tblMaestroObjeto.IdMaestroObjeto }, tblMaestroObjeto);
        }

        // DELETE: api/MaestroObjeto/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblMaestroObjeto>> DeleteTblMaestroObjeto(int id)
        {
            var tblMaestroObjeto = await _context.TblMaestroObjeto.FindAsync(id);
            if (tblMaestroObjeto == null)
            {
                return NotFound();
            }

            _context.TblMaestroObjeto.Remove(tblMaestroObjeto);
            await _context.SaveChangesAsync();

            return tblMaestroObjeto;
        }

        private bool TblMaestroObjetoExists(int id)
        {
            return _context.TblMaestroObjeto.Any(e => e.IdMaestroObjeto == id);
        }
    }
}
