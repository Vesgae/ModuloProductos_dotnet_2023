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
    public class ServiciosController : ControllerBase
    {
        private readonly ProductosServiciosVehiculosContext _context;

        public ServiciosController(ProductosServiciosVehiculosContext context)
        {
            _context = context;
        }

        // GET: api/Servicios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servicio>>> GetServicios()
        {
          if (_context.Servicios == null)
          {
              return NotFound();
          }
            return await _context.Servicios.ToListAsync();
        }

        // GET: api/Servicios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Servicio>> GetServicio(long id)
        {
          if (_context.Servicios == null)
          {
              return NotFound();
          }
            var servicio = await _context.Servicios.FindAsync(id);

            if (servicio == null)
            {
                return NotFound();
            }

            return servicio;
        }

        // PUT: api/Servicios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServicio(long id, Servicio servicio)
        {
            if (id != servicio.Id)
            {
                return BadRequest();
            }

            _context.Entry(servicio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicioExists(id))
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

        // POST: api/Servicios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Servicio>> PostServicio(Servicio servicio)
        {
          if (_context.Servicios == null)
          {
              return Problem("Entity set 'ProductosServiciosVehiculosContext.Servicios'  is null.");
          }
            _context.Servicios.Add(servicio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServicio", new { id = servicio.Id }, servicio);
        }

        // DELETE: api/Servicios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServicio(long id)
        {
            if (_context.Servicios == null)
            {
                return NotFound();
            }
            var servicio = await _context.Servicios.FindAsync(id);
            if (servicio == null)
            {
                return NotFound();
            }

            _context.Servicios.Remove(servicio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServicioExists(long id)
        {
            return (_context.Servicios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
