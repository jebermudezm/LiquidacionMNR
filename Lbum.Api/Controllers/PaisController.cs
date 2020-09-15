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
    public class PaisController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PaisController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Pais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetTblPais()
        {
            return await _context.TblPais.ToListAsync();
        }

        // GET: api/Pais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetTblPais(int id)
        {
            var tblPais = await _context.TblPais.FindAsync(id);

            if (tblPais == null)
            {
                return NotFound();
            }

            return tblPais;
        }

        // PUT: api/Pais/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblPais(int id, Country tblPais)
        {
            if (id != tblPais.IdPais)
            {
                return BadRequest();
            }

            _context.Entry(tblPais).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPaisExists(id))
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

        // POST: api/Pais
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Country>> PostTblPais(Country tblPais)
        {
            _context.TblPais.Add(tblPais);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblPais", new { id = tblPais.IdPais }, tblPais);
        }

        // DELETE: api/Pais/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Country>> DeleteTblPais(int id)
        {
            var tblPais = await _context.TblPais.FindAsync(id);
            if (tblPais == null)
            {
                return NotFound();
            }

            _context.TblPais.Remove(tblPais);
            await _context.SaveChangesAsync();

            return tblPais;
        }

        private bool TblPaisExists(int id)
        {
            return _context.TblPais.Any(e => e.IdPais == id);
        }
    }
}
