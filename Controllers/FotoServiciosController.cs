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
    public class FotoServiciosController : ControllerBase
    {
        private readonly ProductosServiciosVehiculosContext _context;

        public FotoServiciosController(ProductosServiciosVehiculosContext context)
        {
            _context = context;
        }

        // GET: api/FotoServicios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FotoServicio>>> GetFotoServicios()
        {
          if (_context.FotoServicios == null)
          {
              return NotFound();
          }
            return await _context.FotoServicios.ToListAsync();
        }

        // GET: api/FotoServicios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FotoServicio>> GetFotoServicio(long id)
        {
          if (_context.FotoServicios == null)
          {
              return NotFound();
          }
            var fotoServicio = await _context.FotoServicios.FindAsync(id);

            if (fotoServicio == null)
            {
                return NotFound();
            }

            return fotoServicio;
        }

        // PUT: api/FotoServicios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFotoServicio(long id, FotoServicio fotoServicio)
        {
            if (id != fotoServicio.Id)
            {
                return BadRequest();
            }

            _context.Entry(fotoServicio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FotoServicioExists(id))
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

        // POST: api/FotoServicios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FotoServicio>> PostFotoServicio(FotoServicio fotoServicio)
        {
          if (_context.FotoServicios == null)
          {
              return Problem("Entity set 'ProductosServiciosVehiculosContext.FotoServicios'  is null.");
          }
            _context.FotoServicios.Add(fotoServicio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFotoServicio", new { id = fotoServicio.Id }, fotoServicio);
        }

        // DELETE: api/FotoServicios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFotoServicio(long id)
        {
            if (_context.FotoServicios == null)
            {
                return NotFound();
            }
            var fotoServicio = await _context.FotoServicios.FindAsync(id);
            if (fotoServicio == null)
            {
                return NotFound();
            }

            _context.FotoServicios.Remove(fotoServicio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FotoServicioExists(long id)
        {
            return (_context.FotoServicios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
