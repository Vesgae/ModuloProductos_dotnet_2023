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
    public class DisponibilidadRecursoesController : ControllerBase
    {
        private readonly ProductosServiciosVehiculosContext _context;

        public DisponibilidadRecursoesController(ProductosServiciosVehiculosContext context)
        {
            _context = context;
        }

        // GET: api/DisponibilidadRecursoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisponibilidadRecurso>>> GetDisponibilidadRecursos()
        {
          if (_context.DisponibilidadRecursos == null)
          {
              return NotFound();
          }
            return await _context.DisponibilidadRecursos.ToListAsync();
        }

        // GET: api/DisponibilidadRecursoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DisponibilidadRecurso>> GetDisponibilidadRecurso(long id)
        {
          if (_context.DisponibilidadRecursos == null)
          {
              return NotFound();
          }
            var disponibilidadRecurso = await _context.DisponibilidadRecursos.FindAsync(id);

            if (disponibilidadRecurso == null)
            {
                return NotFound();
            }

            return disponibilidadRecurso;
        }

        // PUT: api/DisponibilidadRecursoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDisponibilidadRecurso(long id, DisponibilidadRecurso disponibilidadRecurso)
        {
            if (id != disponibilidadRecurso.Id)
            {
                return BadRequest();
            }

            _context.Entry(disponibilidadRecurso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisponibilidadRecursoExists(id))
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

        // POST: api/DisponibilidadRecursoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DisponibilidadRecurso>> PostDisponibilidadRecurso(DisponibilidadRecurso disponibilidadRecurso)
        {
          if (_context.DisponibilidadRecursos == null)
          {
              return Problem("Entity set 'ProductosServiciosVehiculosContext.DisponibilidadRecursos'  is null.");
          }
            _context.DisponibilidadRecursos.Add(disponibilidadRecurso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDisponibilidadRecurso", new { id = disponibilidadRecurso.Id }, disponibilidadRecurso);
        }

        // DELETE: api/DisponibilidadRecursoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisponibilidadRecurso(long id)
        {
            if (_context.DisponibilidadRecursos == null)
            {
                return NotFound();
            }
            var disponibilidadRecurso = await _context.DisponibilidadRecursos.FindAsync(id);
            if (disponibilidadRecurso == null)
            {
                return NotFound();
            }

            _context.DisponibilidadRecursos.Remove(disponibilidadRecurso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DisponibilidadRecursoExists(long id)
        {
            return (_context.DisponibilidadRecursos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
