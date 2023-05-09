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
    public class ModeloesController : ControllerBase
    {
        private readonly ProductosServiciosVehiculosContext _context;

        public ModeloesController(ProductosServiciosVehiculosContext context)
        {
            _context = context;
        }

        // GET: api/Modeloes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Modelo>>> GetModelos()
        {
          if (_context.Modelos == null)
          {
              return NotFound();
          }
            return await _context.Modelos.ToListAsync();
        }

        // GET: api/Modeloes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Modelo>> GetModelo(long id)
        {
          if (_context.Modelos == null)
          {
              return NotFound();
          }
            var modelo = await _context.Modelos.FindAsync(id);

            if (modelo == null)
            {
                return NotFound();
            }

            return modelo;
        }

        // PUT: api/Modeloes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModelo(long id, Modelo modelo)
        {
            if (id != modelo.Id)
            {
                return BadRequest();
            }

            _context.Entry(modelo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModeloExists(id))
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

        // POST: api/Modeloes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Modelo>> PostModelo(Modelo modelo)
        {
          if (_context.Modelos == null)
          {
              return Problem("Entity set 'ProductosServiciosVehiculosContext.Modelos'  is null.");
          }
            _context.Modelos.Add(modelo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModelo", new { id = modelo.Id }, modelo);
        }

        // DELETE: api/Modeloes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModelo(long id)
        {
            if (_context.Modelos == null)
            {
                return NotFound();
            }
            var modelo = await _context.Modelos.FindAsync(id);
            if (modelo == null)
            {
                return NotFound();
            }

            _context.Modelos.Remove(modelo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModeloExists(long id)
        {
            return (_context.Modelos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
