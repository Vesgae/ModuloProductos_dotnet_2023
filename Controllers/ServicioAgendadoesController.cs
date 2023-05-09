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
    public class ServicioAgendadoesController : ControllerBase
    {
        private readonly ProductosServiciosVehiculosContext _context;

        public ServicioAgendadoesController(ProductosServiciosVehiculosContext context)
        {
            _context = context;
        }

        // GET: api/ServicioAgendadoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicioAgendado>>> GetServicioAgendados()
        {
          if (_context.ServicioAgendados == null)
          {
              return NotFound();
          }
            return await _context.ServicioAgendados.ToListAsync();
        }

        // GET: api/ServicioAgendadoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServicioAgendado>> GetServicioAgendado(long id)
        {
          if (_context.ServicioAgendados == null)
          {
              return NotFound();
          }
            var servicioAgendado = await _context.ServicioAgendados.FindAsync(id);

            if (servicioAgendado == null)
            {
                return NotFound();
            }

            return servicioAgendado;
        }

        // PUT: api/ServicioAgendadoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServicioAgendado(long id, ServicioAgendado servicioAgendado)
        {
            if (id != servicioAgendado.Id)
            {
                return BadRequest();
            }

            _context.Entry(servicioAgendado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicioAgendadoExists(id))
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

        // POST: api/ServicioAgendadoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServicioAgendado>> PostServicioAgendado(ServicioAgendado servicioAgendado)
        {
          if (_context.ServicioAgendados == null)
          {
              return Problem("Entity set 'ProductosServiciosVehiculosContext.ServicioAgendados'  is null.");
          }
            _context.ServicioAgendados.Add(servicioAgendado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServicioAgendado", new { id = servicioAgendado.Id }, servicioAgendado);
        }

        // DELETE: api/ServicioAgendadoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServicioAgendado(long id)
        {
            if (_context.ServicioAgendados == null)
            {
                return NotFound();
            }
            var servicioAgendado = await _context.ServicioAgendados.FindAsync(id);
            if (servicioAgendado == null)
            {
                return NotFound();
            }

            _context.ServicioAgendados.Remove(servicioAgendado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServicioAgendadoExists(long id)
        {
            return (_context.ServicioAgendados?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
