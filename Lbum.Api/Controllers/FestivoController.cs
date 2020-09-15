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
    public class FestivoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FestivoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Festivo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calendar>>> GetTblFestivos()
        {
            return await _context.TblFestivos.ToListAsync();
        }

        // GET: api/Festivo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Calendar>> GetTblFestivos(int id)
        {
            var tblFestivos = await _context.TblFestivos.FindAsync(id);

            if (tblFestivos == null)
            {
                return NotFound();
            }

            return tblFestivos;
        }

        // PUT: api/Festivo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblFestivos(int id, Calendar tblFestivos)
        {
            if (id != tblFestivos.IdFestivo)
            {
                return BadRequest();
            }

            _context.Entry(tblFestivos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblFestivosExists(id))
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

        // POST: api/Festivo
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Calendar>> PostTblFestivos(Calendar tblFestivos)
        {
            _context.TblFestivos.Add(tblFestivos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblFestivos", new { id = tblFestivos.IdFestivo }, tblFestivos);
        }

        // DELETE: api/Festivo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Calendar>> DeleteTblFestivos(int id)
        {
            var tblFestivos = await _context.TblFestivos.FindAsync(id);
            if (tblFestivos == null)
            {
                return NotFound();
            }

            _context.TblFestivos.Remove(tblFestivos);
            await _context.SaveChangesAsync();

            return tblFestivos;
        }

        private bool TblFestivosExists(int id)
        {
            return _context.TblFestivos.Any(e => e.IdFestivo == id);
        }
    }
}
