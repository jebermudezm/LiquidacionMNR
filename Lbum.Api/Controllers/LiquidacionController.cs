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
    public class LiquidacionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LiquidacionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Liquidacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LiquidactionMaster>>> GetTblLiquidacion()
        {
            return await _context.TblLiquidacion.ToListAsync();
        }

        // GET: api/Liquidacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LiquidactionMaster>> GetTblLiquidacion(int id)
        {
            var tblLiquidacion = await _context.TblLiquidacion.FindAsync(id);

            if (tblLiquidacion == null)
            {
                return NotFound();
            }

            return tblLiquidacion;
        }

        // PUT: api/Liquidacion/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblLiquidacion(int id, LiquidactionMaster tblLiquidacion)
        {
            if (id != tblLiquidacion.IdLiquidacion)
            {
                return BadRequest();
            }

            _context.Entry(tblLiquidacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblLiquidacionExists(id))
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

        // POST: api/Liquidacion
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LiquidactionMaster>> PostTblLiquidacion(LiquidactionMaster tblLiquidacion)
        {
            _context.TblLiquidacion.Add(tblLiquidacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblLiquidacion", new { id = tblLiquidacion.IdLiquidacion }, tblLiquidacion);
        }

        // DELETE: api/Liquidacion/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LiquidactionMaster>> DeleteTblLiquidacion(int id)
        {
            var tblLiquidacion = await _context.TblLiquidacion.FindAsync(id);
            if (tblLiquidacion == null)
            {
                return NotFound();
            }

            _context.TblLiquidacion.Remove(tblLiquidacion);
            await _context.SaveChangesAsync();

            return tblLiquidacion;
        }

        private bool TblLiquidacionExists(int id)
        {
            return _context.TblLiquidacion.Any(e => e.IdLiquidacion == id);
        }
    }
}
