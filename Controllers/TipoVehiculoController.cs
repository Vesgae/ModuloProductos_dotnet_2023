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
    [Route("[controller]")]
    [ApiController]
    public class TipoVehiculoController : ControllerBase
    {
        private readonly ProductosServiciosVehiculosContext _context;

        public TipoVehiculoController(ProductosServiciosVehiculosContext context)
        {
            _context = context;
        }

        // GET: api/TipoVehiculo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoVehiculo>>> GetTipoVehiculos()
        {
          if (_context.TipoVehiculos == null)
          {
              return NotFound();
          }
            return await _context.TipoVehiculos.ToListAsync();
        }

        // GET: api/TipoVehiculo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoVehiculo>> GetTipoVehiculo(long id)
        {
          if (_context.TipoVehiculos == null)
          {
              return NotFound();
          }
            var tipoVehiculo = await _context.TipoVehiculos.FindAsync(id);

            if (tipoVehiculo == null)
            {
                return NotFound();
            }

            return tipoVehiculo;
        }

        // PUT: api/TipoVehiculo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoVehiculo(long id, TipoVehiculo tipoVehiculo)
        {
            if (id != tipoVehiculo.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoVehiculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoVehiculoExists(id))
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

        // POST: api/TipoVehiculo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoVehiculo>> PostTipoVehiculo(TipoVehiculo tipoVehiculo)
        {
          if (_context.TipoVehiculos == null)
          {
              return Problem("Entity set 'ProductosServiciosVehiculosContext.TipoVehiculos'  is null.");
          }
            _context.TipoVehiculos.Add(tipoVehiculo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoVehiculo", new { id = tipoVehiculo.Id }, tipoVehiculo);
        }

        // DELETE: api/TipoVehiculo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoVehiculo(long id)
        {
            if (_context.TipoVehiculos == null)
            {
                return NotFound();
            }
            var tipoVehiculo = await _context.TipoVehiculos.FindAsync(id);
            if (tipoVehiculo == null)
            {
                return NotFound();
            }

            _context.TipoVehiculos.Remove(tipoVehiculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoVehiculoExists(long id)
        {
            return (_context.TipoVehiculos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
