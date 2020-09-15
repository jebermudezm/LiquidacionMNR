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
    public class ResultadoLiquidacionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ResultadoLiquidacionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ResultadoLiquidacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LiquidationDetail>>> GetTblResultadoLiquidacion()
        {
            return await _context.TblResultadoLiquidacion.ToListAsync();
        }

        // GET: api/ResultadoLiquidacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LiquidationDetail>> GetTblResultadoLiquidacion(int id)
        {
            var tblResultadoLiquidacion = await _context.TblResultadoLiquidacion.FindAsync(id);

            if (tblResultadoLiquidacion == null)
            {
                return NotFound();
            }

            return tblResultadoLiquidacion;
        }

        // PUT: api/ResultadoLiquidacion/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblResultadoLiquidacion(int id, LiquidationDetail tblResultadoLiquidacion)
        {
            if (id != tblResultadoLiquidacion.IdResultadoLiquidacion)
            {
                return BadRequest();
            }

            _context.Entry(tblResultadoLiquidacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblResultadoLiquidacionExists(id))
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

        // POST: api/ResultadoLiquidacion
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LiquidationDetail>> PostTblResultadoLiquidacion(LiquidationDetail tblResultadoLiquidacion)
        {
            _context.TblResultadoLiquidacion.Add(tblResultadoLiquidacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblResultadoLiquidacion", new { id = tblResultadoLiquidacion.IdResultadoLiquidacion }, tblResultadoLiquidacion);
        }

        // DELETE: api/ResultadoLiquidacion/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LiquidationDetail>> DeleteTblResultadoLiquidacion(int id)
        {
            var tblResultadoLiquidacion = await _context.TblResultadoLiquidacion.FindAsync(id);
            if (tblResultadoLiquidacion == null)
            {
                return NotFound();
            }

            _context.TblResultadoLiquidacion.Remove(tblResultadoLiquidacion);
            await _context.SaveChangesAsync();

            return tblResultadoLiquidacion;
        }

        private bool TblResultadoLiquidacionExists(int id)
        {
            return _context.TblResultadoLiquidacion.Any(e => e.IdResultadoLiquidacion == id);
        }
    }
}
