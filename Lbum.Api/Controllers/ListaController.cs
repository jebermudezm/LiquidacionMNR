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
    public class ListaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ListaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Lista
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListMaster>>> GetTblListas()
        {
            return await _context.TblListas.ToListAsync();
        }

        // GET: api/Lista/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ListMaster>> GetTblListas(int id)
        {
            var tblListas = await _context.TblListas.FindAsync(id);

            if (tblListas == null)
            {
                return NotFound();
            }

            return tblListas;
        }

        // PUT: api/Lista/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblListas(int id, ListMaster tblListas)
        {
            if (id != tblListas.IdLista)
            {
                return BadRequest();
            }

            _context.Entry(tblListas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblListasExists(id))
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

        // POST: api/Lista
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ListMaster>> PostTblListas(ListMaster tblListas)
        {
            _context.TblListas.Add(tblListas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblListas", new { id = tblListas.IdLista }, tblListas);
        }

        // DELETE: api/Lista/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ListMaster>> DeleteTblListas(int id)
        {
            var tblListas = await _context.TblListas.FindAsync(id);
            if (tblListas == null)
            {
                return NotFound();
            }

            _context.TblListas.Remove(tblListas);
            await _context.SaveChangesAsync();

            return tblListas;
        }

        private bool TblListasExists(int id)
        {
            return _context.TblListas.Any(e => e.IdLista == id);
        }
    }
}
