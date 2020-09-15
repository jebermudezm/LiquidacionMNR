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
    public class ConceptoMaestroObjeto : ControllerBase
    {
        private readonly AppDbContext _context;

        public ConceptoMaestroObjeto(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ConceptoMaestroObjeto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblConceptoMaestroObjeto>>> GetTblConceptoMaestroObjeto()
        {
            return await _context.TblConceptoMaestroObjeto.ToListAsync();
        }

        // GET: api/ConceptoMaestroObjeto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblConceptoMaestroObjeto>> GetTblConceptoMaestroObjeto(int id)
        {
            var tblConceptoMaestroObjeto = await _context.TblConceptoMaestroObjeto.FindAsync(id);

            if (tblConceptoMaestroObjeto == null)
            {
                return NotFound();
            }

            return tblConceptoMaestroObjeto;
        }

        // PUT: api/ConceptoMaestroObjeto/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblConceptoMaestroObjeto(int id, TblConceptoMaestroObjeto tblConceptoMaestroObjeto)
        {
            if (id != tblConceptoMaestroObjeto.IdConceptoMaestroObjeto)
            {
                return BadRequest();
            }

            _context.Entry(tblConceptoMaestroObjeto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblConceptoMaestroObjetoExists(id))
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

        // POST: api/ConceptoMaestroObjeto
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblConceptoMaestroObjeto>> PostTblConceptoMaestroObjeto(TblConceptoMaestroObjeto tblConceptoMaestroObjeto)
        {
            _context.TblConceptoMaestroObjeto.Add(tblConceptoMaestroObjeto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblConceptoMaestroObjeto", new { id = tblConceptoMaestroObjeto.IdConceptoMaestroObjeto }, tblConceptoMaestroObjeto);
        }

        // DELETE: api/ConceptoMaestroObjeto/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblConceptoMaestroObjeto>> DeleteTblConceptoMaestroObjeto(int id)
        {
            var tblConceptoMaestroObjeto = await _context.TblConceptoMaestroObjeto.FindAsync(id);
            if (tblConceptoMaestroObjeto == null)
            {
                return NotFound();
            }

            _context.TblConceptoMaestroObjeto.Remove(tblConceptoMaestroObjeto);
            await _context.SaveChangesAsync();

            return tblConceptoMaestroObjeto;
        }

        private bool TblConceptoMaestroObjetoExists(int id)
        {
            return _context.TblConceptoMaestroObjeto.Any(e => e.IdConceptoMaestroObjeto == id);
        }
    }
}
