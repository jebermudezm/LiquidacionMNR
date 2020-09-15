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
    public class EncabezadoFacturaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EncabezadoFacturaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/EncabezadoFactura
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblEncabezadoFactura>>> GetTblEncabezadoFactura()
        {
            return await _context.TblEncabezadoFactura.ToListAsync();
        }

        // GET: api/EncabezadoFactura/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblEncabezadoFactura>> GetTblEncabezadoFactura(int id)
        {
            var tblEncabezadoFactura = await _context.TblEncabezadoFactura.FindAsync(id);

            if (tblEncabezadoFactura == null)
            {
                return NotFound();
            }

            return tblEncabezadoFactura;
        }

        // PUT: api/EncabezadoFactura/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblEncabezadoFactura(int id, TblEncabezadoFactura tblEncabezadoFactura)
        {
            if (id != tblEncabezadoFactura.IdEncabezado)
            {
                return BadRequest();
            }

            _context.Entry(tblEncabezadoFactura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblEncabezadoFacturaExists(id))
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

        // POST: api/EncabezadoFactura
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblEncabezadoFactura>> PostTblEncabezadoFactura(TblEncabezadoFactura tblEncabezadoFactura)
        {
            _context.TblEncabezadoFactura.Add(tblEncabezadoFactura);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblEncabezadoFactura", new { id = tblEncabezadoFactura.IdEncabezado }, tblEncabezadoFactura);
        }

        // DELETE: api/EncabezadoFactura/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblEncabezadoFactura>> DeleteTblEncabezadoFactura(int id)
        {
            var tblEncabezadoFactura = await _context.TblEncabezadoFactura.FindAsync(id);
            if (tblEncabezadoFactura == null)
            {
                return NotFound();
            }

            _context.TblEncabezadoFactura.Remove(tblEncabezadoFactura);
            await _context.SaveChangesAsync();

            return tblEncabezadoFactura;
        }

        private bool TblEncabezadoFacturaExists(int id)
        {
            return _context.TblEncabezadoFactura.Any(e => e.IdEncabezado == id);
        }
    }
}
