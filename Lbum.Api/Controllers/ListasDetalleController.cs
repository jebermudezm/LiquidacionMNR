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
    public class ListasDetalleController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ListasDetalleController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ListasDetalle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblListasDetalle>>> GetTblListasDetalle()
        {
            return await _context.TblListasDetalle.ToListAsync();
        }

        // GET: api/ListasDetalle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblListasDetalle>> GetTblListasDetalle(int id)
        {
            var tblListasDetalle = await _context.TblListasDetalle.FindAsync(id);

            if (tblListasDetalle == null)
            {
                return NotFound();
            }

            return tblListasDetalle;
        }

        // PUT: api/ListasDetalle/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblListasDetalle(int id, TblListasDetalle tblListasDetalle)
        {
            if (id != tblListasDetalle.IdListaDetalle)
            {
                return BadRequest();
            }

            _context.Entry(tblListasDetalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblListasDetalleExists(id))
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

        // POST: api/ListasDetalle
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblListasDetalle>> PostTblListasDetalle(TblListasDetalle tblListasDetalle)
        {
            _context.TblListasDetalle.Add(tblListasDetalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblListasDetalle", new { id = tblListasDetalle.IdListaDetalle }, tblListasDetalle);
        }

        // DELETE: api/ListasDetalle/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblListasDetalle>> DeleteTblListasDetalle(int id)
        {
            var tblListasDetalle = await _context.TblListasDetalle.FindAsync(id);
            if (tblListasDetalle == null)
            {
                return NotFound();
            }

            _context.TblListasDetalle.Remove(tblListasDetalle);
            await _context.SaveChangesAsync();

            return tblListasDetalle;
        }

        private bool TblListasDetalleExists(int id)
        {
            return _context.TblListasDetalle.Any(e => e.IdListaDetalle == id);
        }
    }
}
