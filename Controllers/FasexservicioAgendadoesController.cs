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
    public class FasexservicioAgendadoesController : ControllerBase
    {
        private readonly ProductosServiciosVehiculosContext _context;

        public FasexservicioAgendadoesController(ProductosServiciosVehiculosContext context)
        {
            _context = context;
        }

        // GET: api/FasexservicioAgendadoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FasexservicioAgendado>>> GetFasexservicioAgendados()
        {
          if (_context.FasexservicioAgendados == null)
          {
              return NotFound();
          }
            return await _context.FasexservicioAgendados.ToListAsync();
        }

        // GET: api/FasexservicioAgendadoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FasexservicioAgendado>> GetFasexservicioAgendado(long id)
        {
          if (_context.FasexservicioAgendados == null)
          {
              return NotFound();
          }
            var fasexservicioAgendado = await _context.FasexservicioAgendados.FindAsync(id);

            if (fasexservicioAgendado == null)
            {
                return NotFound();
            }

            return fasexservicioAgendado;
        }

        // PUT: api/FasexservicioAgendadoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFasexservicioAgendado(long id, FasexservicioAgendado fasexservicioAgendado)
        {
            if (id != fasexservicioAgendado.Id)
            {
                return BadRequest();
            }

            _context.Entry(fasexservicioAgendado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FasexservicioAgendadoExists(id))
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

        // POST: api/FasexservicioAgendadoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FasexservicioAgendado>> PostFasexservicioAgendado(FasexservicioAgendado fasexservicioAgendado)
        {
          if (_context.FasexservicioAgendados == null)
          {
              return Problem("Entity set 'ProductosServiciosVehiculosContext.FasexservicioAgendados'  is null.");
          }
            _context.FasexservicioAgendados.Add(fasexservicioAgendado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFasexservicioAgendado", new { id = fasexservicioAgendado.Id }, fasexservicioAgendado);
        }

        // DELETE: api/FasexservicioAgendadoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFasexservicioAgendado(long id)
        {
            if (_context.FasexservicioAgendados == null)
            {
                return NotFound();
            }
            var fasexservicioAgendado = await _context.FasexservicioAgendados.FindAsync(id);
            if (fasexservicioAgendado == null)
            {
                return NotFound();
            }

            _context.FasexservicioAgendados.Remove(fasexservicioAgendado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FasexservicioAgendadoExists(long id)
        {
            return (_context.FasexservicioAgendados?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
