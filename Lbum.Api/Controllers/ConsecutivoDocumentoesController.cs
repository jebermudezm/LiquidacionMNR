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
    public class ConsecutivoDocumentoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ConsecutivoDocumentoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TblConsecutivoDocumentoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsecutiveDocument>>> GetTblConsecutivoDocumento()
        {
            return await _context.TblConsecutivoDocumento.ToListAsync();
        }

        // GET: api/TblConsecutivoDocumentoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsecutiveDocument>> GetTblConsecutivoDocumento(int id)
        {
            var tblConsecutivoDocumento = await _context.TblConsecutivoDocumento.FindAsync(id);

            if (tblConsecutivoDocumento == null)
            {
                return NotFound();
            }

            return tblConsecutivoDocumento;
        }

        // PUT: api/TblConsecutivoDocumentoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblConsecutivoDocumento(int id, ConsecutiveDocument tblConsecutivoDocumento)
        {
            if (id != tblConsecutivoDocumento.IdConsecutivoDocumento)
            {
                return BadRequest();
            }

            _context.Entry(tblConsecutivoDocumento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblConsecutivoDocumentoExists(id))
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

        // POST: api/TblConsecutivoDocumentoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ConsecutiveDocument>> PostTblConsecutivoDocumento(ConsecutiveDocument tblConsecutivoDocumento)
        {
            _context.TblConsecutivoDocumento.Add(tblConsecutivoDocumento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblConsecutivoDocumento", new { id = tblConsecutivoDocumento.IdConsecutivoDocumento }, tblConsecutivoDocumento);
        }

        // DELETE: api/TblConsecutivoDocumentoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ConsecutiveDocument>> DeleteTblConsecutivoDocumento(int id)
        {
            var tblConsecutivoDocumento = await _context.TblConsecutivoDocumento.FindAsync(id);
            if (tblConsecutivoDocumento == null)
            {
                return NotFound();
            }

            _context.TblConsecutivoDocumento.Remove(tblConsecutivoDocumento);
            await _context.SaveChangesAsync();

            return tblConsecutivoDocumento;
        }

        private bool TblConsecutivoDocumentoExists(int id)
        {
            return _context.TblConsecutivoDocumento.Any(e => e.IdConsecutivoDocumento == id);
        }
    }
}
