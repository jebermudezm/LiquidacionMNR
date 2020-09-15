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
    public class DetalleFacturaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DetalleFacturaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/DetalleFactura
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceDetail>>> GetTblDetalleFactura()
        {
            return await _context.TblDetalleFactura.ToListAsync();
        }

        // GET: api/DetalleFactura/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceDetail>> GetTblDetalleFactura(int id)
        {
            var tblDetalleFactura = await _context.TblDetalleFactura.FindAsync(id);

            if (tblDetalleFactura == null)
            {
                return NotFound();
            }

            return tblDetalleFactura;
        }

        // PUT: api/DetalleFactura/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblDetalleFactura(int id, InvoiceDetail tblDetalleFactura)
        {
            if (id != tblDetalleFactura.IdDetalle)
            {
                return BadRequest();
            }

            _context.Entry(tblDetalleFactura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblDetalleFacturaExists(id))
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

        // POST: api/DetalleFactura
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InvoiceDetail>> PostTblDetalleFactura(InvoiceDetail tblDetalleFactura)
        {
            _context.TblDetalleFactura.Add(tblDetalleFactura);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblDetalleFactura", new { id = tblDetalleFactura.IdDetalle }, tblDetalleFactura);
        }

        // DELETE: api/DetalleFactura/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InvoiceDetail>> DeleteTblDetalleFactura(int id)
        {
            var tblDetalleFactura = await _context.TblDetalleFactura.FindAsync(id);
            if (tblDetalleFactura == null)
            {
                return NotFound();
            }

            _context.TblDetalleFactura.Remove(tblDetalleFactura);
            await _context.SaveChangesAsync();

            return tblDetalleFactura;
        }

        private bool TblDetalleFacturaExists(int id)
        {
            return _context.TblDetalleFactura.Any(e => e.IdDetalle == id);
        }
    }
}
