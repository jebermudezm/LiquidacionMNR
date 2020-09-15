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
    public class ReporteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReporteController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Reporte
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Report>>> GetTblReporte()
        {
            return await _context.TblReporte.ToListAsync();
        }

        // GET: api/Reporte/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Report>> GetTblReporte(int id)
        {
            var tblReporte = await _context.TblReporte.FindAsync(id);

            if (tblReporte == null)
            {
                return NotFound();
            }

            return tblReporte;
        }

        // PUT: api/Reporte/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblReporte(int id, Report tblReporte)
        {
            if (id != tblReporte.IdReporte)
            {
                return BadRequest();
            }

            _context.Entry(tblReporte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblReporteExists(id))
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

        // POST: api/Reporte
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Report>> PostTblReporte(Report tblReporte)
        {
            _context.TblReporte.Add(tblReporte);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblReporte", new { id = tblReporte.IdReporte }, tblReporte);
        }

        // DELETE: api/Reporte/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Report>> DeleteTblReporte(int id)
        {
            var tblReporte = await _context.TblReporte.FindAsync(id);
            if (tblReporte == null)
            {
                return NotFound();
            }

            _context.TblReporte.Remove(tblReporte);
            await _context.SaveChangesAsync();

            return tblReporte;
        }

        private bool TblReporteExists(int id)
        {
            return _context.TblReporte.Any(e => e.IdReporte == id);
        }
    }
}
