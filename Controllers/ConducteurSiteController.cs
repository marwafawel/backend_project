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
   // [Authorize]
    public class ConducteurSiteController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ConducteurSiteController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Employee_Site
        [HttpGet]
        public IEnumerable<ConducteurSite> get()
        {
            return _context.ConducteurSite;
        }

        [HttpGet("{Id}")]
        public IQueryable<ConducteurSite> GetByConducteurAsync(Guid Id)
        {
            try
            {
                var ttt = _context.ConducteurSite.Where(u => u.conducteur == Id);
                return ttt;

            }
            catch (Exception)
            {

                throw;
            }

        }



        // PUT: api/Employee_Site/5
        [HttpPut("{id}")]
        public async Task<IActionResult> put([FromRoute] Guid id, [FromBody] ConducteurSite conducteurSite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != conducteurSite.id)
            {
                return BadRequest();
            }

            _context.Entry(conducteurSite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!conducteurSiteExists(id))
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
        
          [HttpPost]
          public async Task<ConducteurSite> post([FromBody] ConducteurSite conducteurSite)
          {

            try
            {
                _context.ConducteurSite.Add(conducteurSite);
                await _context.SaveChangesAsync();
            }

            catch (Exception ex) {
                throw ex;
            }

            return conducteurSite;
          }


      





        // DELETE: api/Employee_Site/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> delete([FromRoute] Guid id)
        {
           
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                //first or default retourne le premiere enregistrement where e.id=id sinon return null
                ConducteurSite conducteurSite = _context.ConducteurSite.FirstOrDefault(e => e.id == id);
                if (conducteurSite == null)
                {
                    return NotFound();
                }

                _context.ConducteurSite.Remove(conducteurSite);
                SaveChanges(_context);

                return Ok(conducteurSite);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private  static void SaveChanges(ApplicationContext ctx)
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

        private bool conducteurSiteExists(Guid id)
        {
            return _context.ConducteurSite.Any(e => e.id == id);
        }
    }
}