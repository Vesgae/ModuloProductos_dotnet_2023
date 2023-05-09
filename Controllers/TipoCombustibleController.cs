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
    public class TipoCombustibleController : ControllerBase
    {
        private readonly ProductosServiciosVehiculosContext _context;

        public TipoCombustibleController(ProductosServiciosVehiculosContext context)
        {
            _context = context;
        }

        // GET: api/TipoCombustible
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoCombustible>>> GetTipoCombustibles()
        {
          if (_context.TipoCombustibles == null)
          {
              return NotFound();
          }
            return await _context.TipoCombustibles.ToListAsync();
        }

        // GET: api/TipoCombustible/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoCombustible>> GetTipoCombustible(long id)
        {
          if (_context.TipoCombustibles == null)
          {
              return NotFound();
          }
            var tipoCombustible = await _context.TipoCombustibles.FindAsync(id);

            if (tipoCombustible == null)
            {
                return NotFound();
            }

            return tipoCombustible;
        }

        // PUT: api/TipoCombustible/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoCombustible(long id, TipoCombustible tipoCombustible)
        {
            if (id != tipoCombustible.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoCombustible).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoCombustibleExists(id))
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

        // POST: api/TipoCombustible
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoCombustible>> PostTipoCombustible(TipoCombustible tipoCombustible)
        {
          if (_context.TipoCombustibles == null)
          {
              return Problem("Entity set 'ProductosServiciosVehiculosContext.TipoCombustibles'  is null.");
          }
            _context.TipoCombustibles.Add(tipoCombustible);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoCombustible", new { id = tipoCombustible.Id }, tipoCombustible);
        }

        // DELETE: api/TipoCombustible/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoCombustible(long id)
        {
            if (_context.TipoCombustibles == null)
            {
                return NotFound();
            }
            var tipoCombustible = await _context.TipoCombustibles.FindAsync(id);
            if (tipoCombustible == null)
            {
                return NotFound();
            }

            _context.TipoCombustibles.Remove(tipoCombustible);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoCombustibleExists(long id)
        {
            return (_context.TipoCombustibles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
