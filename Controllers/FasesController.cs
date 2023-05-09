﻿using System;
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
    public class FasesController : ControllerBase
    {
        private readonly ProductosServiciosVehiculosContext _context;

        public FasesController(ProductosServiciosVehiculosContext context)
        {
            _context = context;
        }

        // GET: api/Fases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fase>>> GetFases()
        {
          if (_context.Fases == null)
          {
              return NotFound();
          }
            return await _context.Fases.ToListAsync();
        }

        // GET: api/Fases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fase>> GetFase(long id)
        {
          if (_context.Fases == null)
          {
              return NotFound();
          }
            var fase = await _context.Fases.FindAsync(id);

            if (fase == null)
            {
                return NotFound();
            }

            return fase;
        }

        // PUT: api/Fases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFase(long id, Fase fase)
        {
            if (id != fase.Id)
            {
                return BadRequest();
            }

            _context.Entry(fase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FaseExists(id))
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

        // POST: api/Fases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fase>> PostFase(Fase fase)
        {
          if (_context.Fases == null)
          {
              return Problem("Entity set 'ProductosServiciosVehiculosContext.Fases'  is null.");
          }
            _context.Fases.Add(fase);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFase", new { id = fase.Id }, fase);
        }

        // DELETE: api/Fases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFase(long id)
        {
            if (_context.Fases == null)
            {
                return NotFound();
            }
            var fase = await _context.Fases.FindAsync(id);
            if (fase == null)
            {
                return NotFound();
            }

            _context.Fases.Remove(fase);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FaseExists(long id)
        {
            return (_context.Fases?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
