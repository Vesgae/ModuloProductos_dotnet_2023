using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modulo_Productos.Entities;

namespace Modulo_Productos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecursoesController : ControllerBase
    {
        private readonly ProductosServiciosVehiculosContext _context;

        public RecursoesController(ProductosServiciosVehiculosContext context)
        {
            _context = context;
        }

        // GET: api/Recursoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recurso>>> GetRecursos()
        {
          if (_context.Recursos == null)
          {
              return NotFound();
          }
            return await _context.Recursos.ToListAsync();
        }

        // GET: api/Recursoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recurso>> GetRecurso(long id)
        {
          if (_context.Recursos == null)
          {
              return NotFound();
          }
            var recurso = await _context.Recursos.FindAsync(id);

            if (recurso == null)
            {
                return NotFound();
            }

            return recurso;
        }

        // PUT: api/Recursoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecurso(long id, Recurso recurso)
        {
            if (id != recurso.Id)
            {
                return BadRequest();
            }

            _context.Entry(recurso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecursoExists(id))
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

        // POST: api/Recursoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Recurso>> PostRecurso(Recurso recurso)
        {
          if (_context.Recursos == null)
          {
              return Problem("Entity set 'ProductosServiciosVehiculosContext.Recursos'  is null.");
          }
            _context.Recursos.Add(recurso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecurso", new { id = recurso.Id }, recurso);
        }

        // DELETE: api/Recursoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecurso(long id)
        {
            if (_context.Recursos == null)
            {
                return NotFound();
            }
            var recurso = await _context.Recursos.FindAsync(id);
            if (recurso == null)
            {
                return NotFound();
            }

            _context.Recursos.Remove(recurso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecursoExists(long id)
        {
            return (_context.Recursos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
