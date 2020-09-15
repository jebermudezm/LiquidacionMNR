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
    public class ContratoFronteraController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContratoFronteraController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ContratoFrontera
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContratEnergyMeter>>> GetTblContratoFrontera()
        {
            return await _context.TblContratoFrontera.ToListAsync();
        }

        // GET: api/ContratoFrontera/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContratEnergyMeter>> GetTblContratoFrontera(int id)
        {
            var tblContratoFrontera = await _context.TblContratoFrontera.FindAsync(id);

            if (tblContratoFrontera == null)
            {
                return NotFound();
            }

            return tblContratoFrontera;
        }

        // PUT: api/ContratoFrontera/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblContratoFrontera(int id, ContratEnergyMeter tblContratoFrontera)
        {
            if (id != tblContratoFrontera.IdContratoFrontera)
            {
                return BadRequest();
            }

            _context.Entry(tblContratoFrontera).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblContratoFronteraExists(id))
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

        // POST: api/ContratoFrontera
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ContratEnergyMeter>> PostTblContratoFrontera(ContratEnergyMeter tblContratoFrontera)
        {
            _context.TblContratoFrontera.Add(tblContratoFrontera);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblContratoFrontera", new { id = tblContratoFrontera.IdContratoFrontera }, tblContratoFrontera);
        }

        // DELETE: api/ContratoFrontera/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContratEnergyMeter>> DeleteTblContratoFrontera(int id)
        {
            var tblContratoFrontera = await _context.TblContratoFrontera.FindAsync(id);
            if (tblContratoFrontera == null)
            {
                return NotFound();
            }

            _context.TblContratoFrontera.Remove(tblContratoFrontera);
            await _context.SaveChangesAsync();

            return tblContratoFrontera;
        }

        private bool TblContratoFronteraExists(int id)
        {
            return _context.TblContratoFrontera.Any(e => e.IdContratoFrontera == id);
        }
    }
}
