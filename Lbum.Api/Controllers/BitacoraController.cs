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
    public class BitacoraController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BitacoraController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Bitacora
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Binnacle>>> GetTblBitacora()
        {
            return await _context.TblBitacora.ToListAsync();
        }

        // GET: api/Bitacora/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Binnacle>> GetTblBitacora(int id)
        {
            var tblBitacora = await _context.TblBitacora.FindAsync(id);

            if (tblBitacora == null)
            {
                return NotFound();
            }

            return tblBitacora;
        }

        // PUT: api/Bitacora/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblBitacora(int id, Binnacle tblBitacora)
        {
            if (id != tblBitacora.IdBitacora)
            {
                return BadRequest();
            }

            _context.Entry(tblBitacora).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblBitacoraExists(id))
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

        // POST: api/Bitacora
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Binnacle>> PostTblBitacora(Binnacle tblBitacora)
        {
            _context.TblBitacora.Add(tblBitacora);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblBitacora", new { id = tblBitacora.IdBitacora }, tblBitacora);
        }

        // DELETE: api/Bitacora/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Binnacle>> DeleteTblBitacora(int id)
        {
            var tblBitacora = await _context.TblBitacora.FindAsync(id);
            if (tblBitacora == null)
            {
                return NotFound();
            }

            _context.TblBitacora.Remove(tblBitacora);
            await _context.SaveChangesAsync();

            return tblBitacora;
        }

        private bool TblBitacoraExists(int id)
        {
            return _context.TblBitacora.Any(e => e.IdBitacora == id);
        }
    }
}
