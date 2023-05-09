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
    public class TipoServiciosController : ControllerBase
    {
        private readonly ProductosServiciosVehiculosContext _context;

        public TipoServiciosController(ProductosServiciosVehiculosContext context)
        {
            _context = context;
        }

        // GET: api/TipoServicios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoServicio>>> GetTipoServicios()
        {
          if (_context.TipoServicios == null)
          {
              return NotFound();
          }
            return await _context.TipoServicios.ToListAsync();
        }

        // GET: api/TipoServicios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoServicio>> GetTipoServicio(long id)
        {
          if (_context.TipoServicios == null)
          {
              return NotFound();
          }
            var tipoServicio = await _context.TipoServicios.FindAsync(id);

            if (tipoServicio == null)
            {
                return NotFound();
            }

            return tipoServicio;
        }

        // PUT: api/TipoServicios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoServicio(long id, TipoServicio tipoServicio)
        {
            if (id != tipoServicio.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoServicio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoServicioExists(id))
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

        // POST: api/TipoServicios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoServicio>> PostTipoServicio(TipoServicio tipoServicio)
        {
          if (_context.TipoServicios == null)
          {
              return Problem("Entity set 'ProductosServiciosVehiculosContext.TipoServicios'  is null.");
          }
            _context.TipoServicios.Add(tipoServicio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoServicio", new { id = tipoServicio.Id }, tipoServicio);
        }

        // DELETE: api/TipoServicios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoServicio(long id)
        {
            if (_context.TipoServicios == null)
            {
                return NotFound();
            }
            var tipoServicio = await _context.TipoServicios.FindAsync(id);
            if (tipoServicio == null)
            {
                return NotFound();
            }

            _context.TipoServicios.Remove(tipoServicio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoServicioExists(long id)
        {
            return (_context.TipoServicios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
