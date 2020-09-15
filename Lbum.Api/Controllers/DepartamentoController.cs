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
    public class DepartamentoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartamentoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Departamento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblDepartamento>>> GetTblDepartamento()
        {
            return await _context.TblDepartamento.ToListAsync();
        }

        // GET: api/Departamento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblDepartamento>> GetTblDepartamento(int id)
        {
            var tblDepartamento = await _context.TblDepartamento.FindAsync(id);

            if (tblDepartamento == null)
            {
                return NotFound();
            }

            return tblDepartamento;
        }

        // PUT: api/Departamento/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblDepartamento(int id, TblDepartamento tblDepartamento)
        {
            if (id != tblDepartamento.IdDepartamento)
            {
                return BadRequest();
            }

            _context.Entry(tblDepartamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblDepartamentoExists(id))
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

        // POST: api/Departamento
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblDepartamento>> PostTblDepartamento(TblDepartamento tblDepartamento)
        {
            _context.TblDepartamento.Add(tblDepartamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblDepartamento", new { id = tblDepartamento.IdDepartamento }, tblDepartamento);
        }

        // DELETE: api/Departamento/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblDepartamento>> DeleteTblDepartamento(int id)
        {
            var tblDepartamento = await _context.TblDepartamento.FindAsync(id);
            if (tblDepartamento == null)
            {
                return NotFound();
            }

            _context.TblDepartamento.Remove(tblDepartamento);
            await _context.SaveChangesAsync();

            return tblDepartamento;
        }

        private bool TblDepartamentoExists(int id)
        {
            return _context.TblDepartamento.Any(e => e.IdDepartamento == id);
        }
    }
}
