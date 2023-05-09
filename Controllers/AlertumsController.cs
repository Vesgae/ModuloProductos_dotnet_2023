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
    public class AlertumsController : ControllerBase
    {
        private readonly ProductosServiciosVehiculosContext _context;

        public AlertumsController(ProductosServiciosVehiculosContext context)
        {
            _context = context;
        }

        // GET: api/Alertums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alertum>>> GetAlerta()
        {
          if (_context.Alerta == null)
          {
              return NotFound();
          }
            return await _context.Alerta.ToListAsync();
        }

        // GET: api/Alertums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alertum>> GetAlertum(long id)
        {
          if (_context.Alerta == null)
          {
              return NotFound();
          }
            var alertum = await _context.Alerta.FindAsync(id);

            if (alertum == null)
            {
                return NotFound();
            }

            return alertum;
        }

        // PUT: api/Alertums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlertum(long id, Alertum alertum)
        {
            if (id != alertum.Id)
            {
                return BadRequest();
            }

            _context.Entry(alertum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlertumExists(id))
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

        // POST: api/Alertums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Alertum>> PostAlertum(Alertum alertum)
        {
          if (_context.Alerta == null)
          {
              return Problem("Entity set 'ProductosServiciosVehiculosContext.Alerta'  is null.");
          }
            _context.Alerta.Add(alertum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlertum", new { id = alertum.Id }, alertum);
        }

        // DELETE: api/Alertums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlertum(long id)
        {
            if (_context.Alerta == null)
            {
                return NotFound();
            }
            var alertum = await _context.Alerta.FindAsync(id);
            if (alertum == null)
            {
                return NotFound();
            }

            _context.Alerta.Remove(alertum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlertumExists(long id)
        {
            return (_context.Alerta?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
