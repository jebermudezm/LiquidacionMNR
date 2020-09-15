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
    public class EmpresaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmpresaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Empresa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetTblEmpresa()
        {
            return await _context.TblEmpresa.ToListAsync();
        }

        // GET: api/Empresa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetTblEmpresa(int id)
        {
            var tblEmpresa = await _context.TblEmpresa.FindAsync(id);

            if (tblEmpresa == null)
            {
                return NotFound();
            }

            return tblEmpresa;
        }

        // PUT: api/Empresa/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblEmpresa(int id, Client tblEmpresa)
        {
            if (id != tblEmpresa.IdEmpresa)
            {
                return BadRequest();
            }

            _context.Entry(tblEmpresa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblEmpresaExists(id))
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

        // POST: api/Empresa
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Client>> PostTblEmpresa(Client tblEmpresa)
        {
            _context.TblEmpresa.Add(tblEmpresa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblEmpresa", new { id = tblEmpresa.IdEmpresa }, tblEmpresa);
        }

        // DELETE: api/Empresa/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Client>> DeleteTblEmpresa(int id)
        {
            var tblEmpresa = await _context.TblEmpresa.FindAsync(id);
            if (tblEmpresa == null)
            {
                return NotFound();
            }

            _context.TblEmpresa.Remove(tblEmpresa);
            await _context.SaveChangesAsync();

            return tblEmpresa;
        }

        private bool TblEmpresaExists(int id)
        {
            return _context.TblEmpresa.Any(e => e.IdEmpresa == id);
        }
    }
}
