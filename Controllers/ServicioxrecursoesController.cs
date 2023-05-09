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
    public class ServicioxrecursoesController : ControllerBase
    {
        private readonly ProductosServiciosVehiculosContext _context;

        public ServicioxrecursoesController(ProductosServiciosVehiculosContext context)
        {
            _context = context;
        }

        // GET: api/Servicioxrecursoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servicioxrecurso>>> GetServicioxrecursos()
        {
          if (_context.Servicioxrecursos == null)
          {
              return NotFound();
          }
            return await _context.Servicioxrecursos.ToListAsync();
        }

        // GET: api/Servicioxrecursoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Servicioxrecurso>> GetServicioxrecurso(long id)
        {
          if (_context.Servicioxrecursos == null)
          {
              return NotFound();
          }
            var servicioxrecurso = await _context.Servicioxrecursos.FindAsync(id);

            if (servicioxrecurso == null)
            {
                return NotFound();
            }

            return servicioxrecurso;
        }

        // PUT: api/Servicioxrecursoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServicioxrecurso(long id, Servicioxrecurso servicioxrecurso)
        {
            if (id != servicioxrecurso.Id)
            {
                return BadRequest();
            }

            _context.Entry(servicioxrecurso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicioxrecursoExists(id))
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

        // POST: api/Servicioxrecursoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Servicioxrecurso>> PostServicioxrecurso(Servicioxrecurso servicioxrecurso)
        {
          if (_context.Servicioxrecursos == null)
          {
              return Problem("Entity set 'ProductosServiciosVehiculosContext.Servicioxrecursos'  is null.");
          }
            _context.Servicioxrecursos.Add(servicioxrecurso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServicioxrecurso", new { id = servicioxrecurso.Id }, servicioxrecurso);
        }

        // DELETE: api/Servicioxrecursoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServicioxrecurso(long id)
        {
            if (_context.Servicioxrecursos == null)
            {
                return NotFound();
            }
            var servicioxrecurso = await _context.Servicioxrecursos.FindAsync(id);
            if (servicioxrecurso == null)
            {
                return NotFound();
            }

            _context.Servicioxrecursos.Remove(servicioxrecurso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServicioxrecursoExists(long id)
        {
            return (_context.Servicioxrecursos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
