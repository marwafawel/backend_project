using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectPFE.Models;
using ProjectPFE.Models.DBContext;

namespace ProjectPFE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class conducteursController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public conducteursController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/conducteurs
        [HttpGet]
        public IEnumerable<conducteur> Getconducteur()
        {
            return _context.conducteur;
        }

        // GET: api/conducteurs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getconducteur([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var conducteur = await _context.conducteur.FindAsync(id);

            if (conducteur == null)
            {
                return NotFound();
            }

            return Ok(conducteur);
        }

        // PUT: api/conducteurs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putconducteur([FromRoute] Guid id, [FromBody] conducteur conducteur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != conducteur.ConducteurId)
            {
                return BadRequest();
            }

            _context.Entry(conducteur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!conducteurExists(id))
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

        // POST: api/conducteurs
        [HttpPost]
        public async Task<IActionResult> Postconducteur([FromBody] conducteur conducteur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _context.conducteur.Add(conducteur);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }


            return CreatedAtAction("Getconducteur", new { id = conducteur.ConducteurId }, conducteur);
        }

        // DELETE: api/conducteurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteconducteur([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var conducteur = await _context.conducteur.FindAsync(id);
            if (conducteur == null)
            {
                return NotFound();
            }

            _context.conducteur.Remove(conducteur);
            await _context.SaveChangesAsync();

            return Ok(conducteur);
        }

        private bool conducteurExists(Guid id)
        {
            return _context.conducteur.Any(e => e.ConducteurId == id);
        }
    }
}