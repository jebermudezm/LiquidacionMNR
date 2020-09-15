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
    public class TipoConceptoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TipoConceptoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoConcepto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeConcept>>> GetTblTipoConcepto()
        {
            return await _context.TblTipoConcepto.ToListAsync();
        }

        // GET: api/TipoConcepto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeConcept>> GetTblTipoConcepto(int id)
        {
            var tblTipoConcepto = await _context.TblTipoConcepto.FindAsync(id);

            if (tblTipoConcepto == null)
            {
                return NotFound();
            }

            return tblTipoConcepto;
        }

        // PUT: api/TipoConcepto/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblTipoConcepto(int id, TypeConcept tblTipoConcepto)
        {
            if (id != tblTipoConcepto.IdTipoConcepto)
            {
                return BadRequest();
            }

            _context.Entry(tblTipoConcepto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblTipoConceptoExists(id))
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

        // POST: api/TipoConcepto
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TypeConcept>> PostTblTipoConcepto(TypeConcept tblTipoConcepto)
        {
            _context.TblTipoConcepto.Add(tblTipoConcepto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblTipoConcepto", new { id = tblTipoConcepto.IdTipoConcepto }, tblTipoConcepto);
        }

        // DELETE: api/TipoConcepto/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TypeConcept>> DeleteTblTipoConcepto(int id)
        {
            var tblTipoConcepto = await _context.TblTipoConcepto.FindAsync(id);
            if (tblTipoConcepto == null)
            {
                return NotFound();
            }

            _context.TblTipoConcepto.Remove(tblTipoConcepto);
            await _context.SaveChangesAsync();

            return tblTipoConcepto;
        }

        private bool TblTipoConceptoExists(int id)
        {
            return _context.TblTipoConcepto.Any(e => e.IdTipoConcepto == id);
        }
    }
}
