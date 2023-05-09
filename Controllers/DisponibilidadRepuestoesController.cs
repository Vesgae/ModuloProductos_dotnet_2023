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
    public class DisponibilidadRepuestoesController : ControllerBase
    {
        private readonly ProductosServiciosVehiculosContext _context;

        public DisponibilidadRepuestoesController(ProductosServiciosVehiculosContext context)
        {
            _context = context;
        }

        // GET: api/DisponibilidadRepuestoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisponibilidadRepuesto>>> GetDisponibilidadRepuestos()
        {
          if (_context.DisponibilidadRepuestos == null)
          {
              return NotFound();
          }
            return await _context.DisponibilidadRepuestos.ToListAsync();
        }

        // GET: api/DisponibilidadRepuestoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DisponibilidadRepuesto>> GetDisponibilidadRepuesto(long id)
        {
          if (_context.DisponibilidadRepuestos == null)
          {
              return NotFound();
          }
            var disponibilidadRepuesto = await _context.DisponibilidadRepuestos.FindAsync(id);

            if (disponibilidadRepuesto == null)
            {
                return NotFound();
            }

            return disponibilidadRepuesto;
        }

        // PUT: api/DisponibilidadRepuestoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDisponibilidadRepuesto(long id, DisponibilidadRepuesto disponibilidadRepuesto)
        {
            if (id != disponibilidadRepuesto.Id)
            {
                return BadRequest();
            }

            _context.Entry(disponibilidadRepuesto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisponibilidadRepuestoExists(id))
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

        // POST: api/DisponibilidadRepuestoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DisponibilidadRepuesto>> PostDisponibilidadRepuesto(DisponibilidadRepuesto disponibilidadRepuesto)
        {
          if (_context.DisponibilidadRepuestos == null)
          {
              return Problem("Entity set 'ProductosServiciosVehiculosContext.DisponibilidadRepuestos'  is null.");
          }
            _context.DisponibilidadRepuestos.Add(disponibilidadRepuesto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDisponibilidadRepuesto", new { id = disponibilidadRepuesto.Id }, disponibilidadRepuesto);
        }

        // DELETE: api/DisponibilidadRepuestoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisponibilidadRepuesto(long id)
        {
            if (_context.DisponibilidadRepuestos == null)
            {
                return NotFound();
            }
            var disponibilidadRepuesto = await _context.DisponibilidadRepuestos.FindAsync(id);
            if (disponibilidadRepuesto == null)
            {
                return NotFound();
            }

            _context.DisponibilidadRepuestos.Remove(disponibilidadRepuesto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DisponibilidadRepuestoExists(long id)
        {
            return (_context.DisponibilidadRepuestos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
