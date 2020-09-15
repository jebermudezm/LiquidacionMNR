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
    public class ConceptoFronteraController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ConceptoFronteraController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ConceptoFrontera
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblConceptoFrontera>>> GetTblConceptoFrontera()
        {
            return await _context.TblConceptoFrontera.ToListAsync();
        }

        // GET: api/ConceptoFrontera/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblConceptoFrontera>> GetTblConceptoFrontera(int id)
        {
            var tblConceptoFrontera = await _context.TblConceptoFrontera.FindAsync(id);

            if (tblConceptoFrontera == null)
            {
                return NotFound();
            }

            return tblConceptoFrontera;
        }

        // PUT: api/ConceptoFrontera/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblConceptoFrontera(int id, TblConceptoFrontera tblConceptoFrontera)
        {
            if (id != tblConceptoFrontera.IdConceptoFrontera)
            {
                return BadRequest();
            }

            _context.Entry(tblConceptoFrontera).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblConceptoFronteraExists(id))
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

        // POST: api/ConceptoFrontera
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblConceptoFrontera>> PostTblConceptoFrontera(TblConceptoFrontera tblConceptoFrontera)
        {
            _context.TblConceptoFrontera.Add(tblConceptoFrontera);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblConceptoFrontera", new { id = tblConceptoFrontera.IdConceptoFrontera }, tblConceptoFrontera);
        }

        // DELETE: api/ConceptoFrontera/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblConceptoFrontera>> DeleteTblConceptoFrontera(int id)
        {
            var tblConceptoFrontera = await _context.TblConceptoFrontera.FindAsync(id);
            if (tblConceptoFrontera == null)
            {
                return NotFound();
            }

            _context.TblConceptoFrontera.Remove(tblConceptoFrontera);
            await _context.SaveChangesAsync();

            return tblConceptoFrontera;
        }

        private bool TblConceptoFronteraExists(int id)
        {
            return _context.TblConceptoFrontera.Any(e => e.IdConceptoFrontera == id);
        }
    }
}
