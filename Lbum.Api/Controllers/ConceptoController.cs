using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lbum.Data.Models;
using Lbum.Domain.Cont;

namespace Lbum.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConceptoController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConceptoDomainCont _conceptoDomain;

        public ConceptoController(AppDbContext context, IConceptoDomainCont conceptoDomain)
        {
            _context = context;
            _conceptoDomain = conceptoDomain;
        }

        // GET: api/Concepto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Concept>>> GetTblConcepto()
        {
            //return await _context.TblConcepto.ToListAsync();
            return await _conceptoDomain.ConsultarConcepto().ToListAsync();
        }

        //// GET: api/Concepto
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<TblConcepto>>> GetTblConcepto()
        //{
        //    return await _context.TblConcepto.ToListAsync();
        //}

        // GET: api/Concepto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Concept>> GetTblConcepto(int id)
        {
            var tblConcepto = await _context.TblConcepto.FindAsync(id);

            if (tblConcepto == null)
            {
                return NotFound();
            }

            return tblConcepto;
        }

        // PUT: api/Concepto/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblConcepto(int id, Concept tblConcepto)
        {
            if (id != tblConcepto.IdConcepto)
            {
                return BadRequest();
            }

            _context.Entry(tblConcepto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblConceptoExists(id))
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

        // POST: api/Concepto
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Concept>> PostTblConcepto(Concept tblConcepto)
        {
            _context.TblConcepto.Add(tblConcepto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblConcepto", new { id = tblConcepto.IdConcepto }, tblConcepto);
        }

        // DELETE: api/Concepto/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Concept>> DeleteTblConcepto(int id)
        {
            var tblConcepto = await _context.TblConcepto.FindAsync(id);
            if (tblConcepto == null)
            {
                return NotFound();
            }

            _context.TblConcepto.Remove(tblConcepto);
            await _context.SaveChangesAsync();

            return tblConcepto;
        }

        private bool TblConceptoExists(int id)
        {
            return _context.TblConcepto.Any(e => e.IdConcepto == id);
        }
    }
}
