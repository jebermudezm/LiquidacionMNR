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
    public class CiudadController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CiudadController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Ciudad
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetTblCiudad()
        {
            return await _context.TblCiudad.ToListAsync();
        }

        // GET: api/Ciudad/5
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetTblCiudad(int id)
        {
            var tblCiudad = await _context.TblCiudad.FindAsync(id);

            if (tblCiudad == null)
            {
                return NotFound();
            }

            return tblCiudad;
        }

        // PUT: api/Ciudad/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblCiudad(int id, City tblCiudad)
        {
            if (id != tblCiudad.IdCiudad)
            {
                return BadRequest();
            }

            _context.Entry(tblCiudad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCiudadExists(id))
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

        // POST: api/Ciudad
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<City>> PostTblCiudad(City tblCiudad)
        {
            _context.TblCiudad.Add(tblCiudad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblCiudad", new { id = tblCiudad.IdCiudad }, tblCiudad);
        }

        // DELETE: api/Ciudad/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<City>> DeleteTblCiudad(int id)
        {
            var tblCiudad = await _context.TblCiudad.FindAsync(id);
            if (tblCiudad == null)
            {
                return NotFound();
            }

            _context.TblCiudad.Remove(tblCiudad);
            await _context.SaveChangesAsync();

            return tblCiudad;
        }

        private bool TblCiudadExists(int id)
        {
            return _context.TblCiudad.Any(e => e.IdCiudad == id);
        }
    }
}
