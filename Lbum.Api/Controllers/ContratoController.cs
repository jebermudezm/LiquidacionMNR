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
    public class ContratoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContratoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Contrato
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contrat>>> GetTblContrato()
        {
            return await _context.TblContrato.ToListAsync();
        }

        // GET: api/Contrato/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contrat>> GetTblContrato(int id)
        {
            var tblContrato = await _context.TblContrato.FindAsync(id);

            if (tblContrato == null)
            {
                return NotFound();
            }

            return tblContrato;
        }

        // PUT: api/Contrato/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblContrato(int id, Contrat tblContrato)
        {
            if (id != tblContrato.IdContrato)
            {
                return BadRequest();
            }

            _context.Entry(tblContrato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblContratoExists(id))
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

        // POST: api/Contrato
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Contrat>> PostTblContrato(Contrat tblContrato)
        {
            _context.TblContrato.Add(tblContrato);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblContrato", new { id = tblContrato.IdContrato }, tblContrato);
        }

        // DELETE: api/Contrato/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Contrat>> DeleteTblContrato(int id)
        {
            var tblContrato = await _context.TblContrato.FindAsync(id);
            if (tblContrato == null)
            {
                return NotFound();
            }

            _context.TblContrato.Remove(tblContrato);
            await _context.SaveChangesAsync();

            return tblContrato;
        }

        private bool TblContratoExists(int id)
        {
            return _context.TblContrato.Any(e => e.IdContrato == id);
        }
    }
}
