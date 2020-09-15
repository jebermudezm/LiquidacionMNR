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
    public class FronteraController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FronteraController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Frontera
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnergyMeter>>> GetTblFrontera()
        {
            return await _context.TblFrontera.ToListAsync();
        }

        // GET: api/Frontera/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnergyMeter>> GetTblFrontera(int id)
        {
            var tblFrontera = await _context.TblFrontera.FindAsync(id);

            if (tblFrontera == null)
            {
                return NotFound();
            }

            return tblFrontera;
        }

        // PUT: api/Frontera/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblFrontera(int id, EnergyMeter tblFrontera)
        {
            if (id != tblFrontera.IdFrontera)
            {
                return BadRequest();
            }

            _context.Entry(tblFrontera).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblFronteraExists(id))
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

        // POST: api/Frontera
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EnergyMeter>> PostTblFrontera(EnergyMeter tblFrontera)
        {
            _context.TblFrontera.Add(tblFrontera);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblFrontera", new { id = tblFrontera.IdFrontera }, tblFrontera);
        }

        // DELETE: api/Frontera/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EnergyMeter>> DeleteTblFrontera(int id)
        {
            var tblFrontera = await _context.TblFrontera.FindAsync(id);
            if (tblFrontera == null)
            {
                return NotFound();
            }

            _context.TblFrontera.Remove(tblFrontera);
            await _context.SaveChangesAsync();

            return tblFrontera;
        }

        private bool TblFronteraExists(int id)
        {
            return _context.TblFrontera.Any(e => e.IdFrontera == id);
        }
    }
}
