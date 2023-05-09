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
    public class FotoProductoesController : ControllerBase
    {
        private readonly ProductosServiciosVehiculosContext _context;

        public FotoProductoesController(ProductosServiciosVehiculosContext context)
        {
            _context = context;
        }

        // GET: api/FotoProductoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FotoProducto>>> GetFotoProductos()
        {
          if (_context.FotoProductos == null)
          {
              return NotFound();
          }
            return await _context.FotoProductos.ToListAsync();
        }

        // GET: api/FotoProductoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FotoProducto>> GetFotoProducto(long id)
        {
          if (_context.FotoProductos == null)
          {
              return NotFound();
          }
            var fotoProducto = await _context.FotoProductos.FindAsync(id);

            if (fotoProducto == null)
            {
                return NotFound();
            }

            return fotoProducto;
        }

        // PUT: api/FotoProductoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFotoProducto(long id, FotoProducto fotoProducto)
        {
            if (id != fotoProducto.Id)
            {
                return BadRequest();
            }

            _context.Entry(fotoProducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FotoProductoExists(id))
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

        // POST: api/FotoProductoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FotoProducto>> PostFotoProducto(FotoProducto fotoProducto)
        {
          if (_context.FotoProductos == null)
          {
              return Problem("Entity set 'ProductosServiciosVehiculosContext.FotoProductos'  is null.");
          }
            _context.FotoProductos.Add(fotoProducto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFotoProducto", new { id = fotoProducto.Id }, fotoProducto);
        }

        // DELETE: api/FotoProductoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFotoProducto(long id)
        {
            if (_context.FotoProductos == null)
            {
                return NotFound();
            }
            var fotoProducto = await _context.FotoProductos.FindAsync(id);
            if (fotoProducto == null)
            {
                return NotFound();
            }

            _context.FotoProductos.Remove(fotoProducto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FotoProductoExists(long id)
        {
            return (_context.FotoProductos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
