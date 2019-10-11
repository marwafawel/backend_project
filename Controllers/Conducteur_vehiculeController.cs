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
    public class Conducteur_vehiculeController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public Conducteur_vehiculeController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Conducteur_vehicule
        [HttpGet]
        public IEnumerable<Conducteur_vehicule> GetEmployees_Vehicules()
        {
            return _context.Employees_Vehicules;
        }

   /*    // GET: api/Conducteur_vehicule/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetConducteur_vehicule([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var conducteur_vehicule = await _context.Employees_Vehicules.FindAsync(id);

            if (conducteur_vehicule == null)
            {
                return NotFound();
            }

            return Ok(conducteur_vehicule);
        }*/

        // PUT: api/Conducteur_vehicule/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConducteur_vehicule([FromRoute] Guid id, [FromBody] Conducteur_vehicule conducteur_vehicule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != conducteur_vehicule.Id)
            {
                return BadRequest();
            }

            _context.Entry(conducteur_vehicule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Conducteur_vehiculeExists(id))
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
        //get by vehicule id

        [HttpGet("{VehiculeId}", Name = "GetvehID")]
        public IQueryable<Conducteur_vehicule> GetByEmployeAsync(Guid VehiculeId)
        {
            try
            {
                return _context.Employees_Vehicules.Where(u => u.VehiculeId == VehiculeId);

            }
            catch (Exception)
            {

                throw;
            }

        }



        // POST: api/Conducteur_vehicule
        [HttpPost]
        public async Task<IActionResult> PostConducteur_vehicule([FromBody] Conducteur_vehicule conducteur_vehicule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Employees_Vehicules.Add(conducteur_vehicule);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                if (Conducteur_vehiculeExists(conducteur_vehicule.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetConducteur_vehicule", new { id = conducteur_vehicule.Id }, conducteur_vehicule);
        }
        
       

        // DELETE: api/Conducteur_vehicule/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConducteur_vehicule([FromRoute] Guid id)
        {
            try { 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var conducteur_vehicule = _context.Employees_Vehicules.FirstOrDefault(e => e.Id == id);
            
                if (conducteur_vehicule == null)
            {
                return NotFound();
            }

            _context.Employees_Vehicules.Remove(conducteur_vehicule);
             SaveChanges(_context);

                return Ok(conducteur_vehicule);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        private static void SaveChanges(ApplicationContext ctx)
        {
            bool saveFailed;
            do
            {
                saveFailed = false;

                try
                {
                    ctx.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;
                    //System.Diagnostics.Trace.TraceWarning("{1}------DbUpdateConcurrencyException {0}", ex.ToString(), DateTime.Now);
                    // Update the values of the entity that failed to save from the store
                    ex.Entries.Single().Reload();
                }

            } while (saveFailed);
        }

        private bool Conducteur_vehiculeExists(Guid id)
        {
            return _context.Employees_Vehicules.Any(e => e.Id == id);
        }
    }
}