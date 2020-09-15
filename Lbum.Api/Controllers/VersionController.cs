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
    public class VersionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VersionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Version
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblVersion>>> GetTblVersion()
        {
            return await _context.TblVersion.ToListAsync();
        }

        // GET: api/Version/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblVersion>> GetTblVersion(int id)
        {
            var tblVersion = await _context.TblVersion.FindAsync(id);

            if (tblVersion == null)
            {
                return NotFound();
            }

            return tblVersion;
        }

        // PUT: api/Version/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblVersion(int id, TblVersion tblVersion)
        {
            if (id != tblVersion.IdVersion)
            {
                return BadRequest();
            }

            _context.Entry(tblVersion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblVersionExists(id))
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

        // POST: api/Version
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblVersion>> PostTblVersion(TblVersion tblVersion)
        {
            _context.TblVersion.Add(tblVersion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblVersion", new { id = tblVersion.IdVersion }, tblVersion);
        }

        // DELETE: api/Version/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblVersion>> DeleteTblVersion(int id)
        {
            var tblVersion = await _context.TblVersion.FindAsync(id);
            if (tblVersion == null)
            {
                return NotFound();
            }

            _context.TblVersion.Remove(tblVersion);
            await _context.SaveChangesAsync();

            return tblVersion;
        }

        private bool TblVersionExists(int id)
        {
            return _context.TblVersion.Any(e => e.IdVersion == id);
        }
    }
}
