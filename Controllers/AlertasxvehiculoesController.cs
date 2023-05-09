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
    public class AlertasxvehiculoesController : ControllerBase
    {
        private readonly ProductosServiciosVehiculosContext _context;

        public AlertasxvehiculoesController(ProductosServiciosVehiculosContext context)
        {
            _context = context;
        }

        // GET: api/Alertasxvehiculoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alertasxvehiculo>>> GetAlertasxvehiculos()
        {
          if (_context.Alertasxvehiculos == null)
          {
              return NotFound();
          }
            return await _context.Alertasxvehiculos.ToListAsync();
        }

        // GET: api/Alertasxvehiculoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alertasxvehiculo>> GetAlertasxvehiculo(long id)
        {
          if (_context.Alertasxvehiculos == null)
          {
              return NotFound();
          }
            var alertasxvehiculo = await _context.Alertasxvehiculos.FindAsync(id);

            if (alertasxvehiculo == null)
            {
                return NotFound();
            }

            return alertasxvehiculo;
        }

        // PUT: api/Alertasxvehiculoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlertasxvehiculo(long id, Alertasxvehiculo alertasxvehiculo)
        {
            if (id != alertasxvehiculo.Id)
            {
                return BadRequest();
            }

            _context.Entry(alertasxvehiculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlertasxvehiculoExists(id))
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

        // POST: api/Alertasxvehiculoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Alertasxvehiculo>> PostAlertasxvehiculo(Alertasxvehiculo alertasxvehiculo)
        {
          if (_context.Alertasxvehiculos == null)
          {
              return Problem("Entity set 'ProductosServiciosVehiculosContext.Alertasxvehiculos'  is null.");
          }
            _context.Alertasxvehiculos.Add(alertasxvehiculo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlertasxvehiculo", new { id = alertasxvehiculo.Id }, alertasxvehiculo);
        }

        // DELETE: api/Alertasxvehiculoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlertasxvehiculo(long id)
        {
            if (_context.Alertasxvehiculos == null)
            {
                return NotFound();
            }
            var alertasxvehiculo = await _context.Alertasxvehiculos.FindAsync(id);
            if (alertasxvehiculo == null)
            {
                return NotFound();
            }

            _context.Alertasxvehiculos.Remove(alertasxvehiculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlertasxvehiculoExists(long id)
        {
            return (_context.Alertasxvehiculos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
