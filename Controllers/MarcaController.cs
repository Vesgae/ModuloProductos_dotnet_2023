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
    public class MarcaController : ControllerBase
    {
        private readonly ProductosServiciosVehiculosContext _context;

        public MarcaController(ProductosServiciosVehiculosContext context)
        {
            _context = context;
        }

        // GET: api/Marca
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Marca>>> GetMarcas()
        {
          if (_context.Marcas == null)
          {
              return NotFound();
          }
            return await _context.Marcas.ToListAsync();
        }

        // GET: api/Marca/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Marca>> GetMarca(long id)
        {
          if (_context.Marcas == null)
          {
              return NotFound();
          }
            var marca = await _context.Marcas.FindAsync(id);

            if (marca == null)
            {
                return NotFound();
            }

            return marca;
        }

        // PUT: api/Marca/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarca(long id, Marca marca)
        {
            if (id != marca.Id)
            {
                return BadRequest();
            }

            _context.Entry(marca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarcaExists(id))
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

        // POST: api/Marca
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Marca>> PostMarca(Marca marca)
        {
          if (_context.Marcas == null)
          {
              return Problem("Entity set 'ProductosServiciosVehiculosContext.Marcas'  is null.");
          }
            _context.Marcas.Add(marca);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarca", new { id = marca.Id }, marca);
        }

        // DELETE: api/Marca/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarca(long id)
        {
            if (_context.Marcas == null)
            {
                return NotFound();
            }
            var marca = await _context.Marcas.FindAsync(id);
            if (marca == null)
            {
                return NotFound();
            }

            _context.Marcas.Remove(marca);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MarcaExists(long id)
        {
            return (_context.Marcas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
