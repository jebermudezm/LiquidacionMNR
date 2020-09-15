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
    public class ConceptoContratoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ConceptoContratoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ConceptoContrato
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblConceptoContrato>>> GetTblConceptoContrato()
        {
            return await _context.TblConceptoContrato.ToListAsync();
        }

        // GET: api/ConceptoContrato/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblConceptoContrato>> GetTblConceptoContrato(int id)
        {
            var tblConceptoContrato = await _context.TblConceptoContrato.FindAsync(id);

            if (tblConceptoContrato == null)
            {
                return NotFound();
            }

            return tblConceptoContrato;
        }

        // PUT: api/ConceptoContrato/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblConceptoContrato(int id, TblConceptoContrato tblConceptoContrato)
        {
            if (id != tblConceptoContrato.IdConceptoContrato)
            {
                return BadRequest();
            }

            _context.Entry(tblConceptoContrato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblConceptoContratoExists(id))
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

        // POST: api/ConceptoContrato
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblConceptoContrato>> PostTblConceptoContrato(TblConceptoContrato tblConceptoContrato)
        {
            _context.TblConceptoContrato.Add(tblConceptoContrato);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblConceptoContrato", new { id = tblConceptoContrato.IdConceptoContrato }, tblConceptoContrato);
        }

        // DELETE: api/ConceptoContrato/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblConceptoContrato>> DeleteTblConceptoContrato(int id)
        {
            var tblConceptoContrato = await _context.TblConceptoContrato.FindAsync(id);
            if (tblConceptoContrato == null)
            {
                return NotFound();
            }

            _context.TblConceptoContrato.Remove(tblConceptoContrato);
            await _context.SaveChangesAsync();

            return tblConceptoContrato;
        }

        private bool TblConceptoContratoExists(int id)
        {
            return _context.TblConceptoContrato.Any(e => e.IdConceptoContrato == id);
        }
    }
}
