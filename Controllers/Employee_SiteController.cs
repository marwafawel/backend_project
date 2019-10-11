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
    public class Employee_SiteController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public Employee_SiteController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Employee_Site
        [HttpGet]
        public IEnumerable<Employee_Site> GetEmployees_Sites()
        {
            return _context.Employees_Sites;
        }

        /*// GET: api/Employee_Site/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee_Site([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee_Site = await _context.Employees_Sites.FindAsync(id);
            //var employee_Site = await _context.Employees_Sites.GetByEmployeeId(id);
            if (employee_Site == null)
            {
                return NotFound();
            }

            return Ok(employee_Site);
        }*/

        [HttpGet("{Id}", Name = "GetUserPermissionByID")]
        public IQueryable<Employee_Site> GetByEmployeAsync(string Id)
        {
            try
            {
                return _context.Employees_Sites.Where(u => u.employeeId == Id);

            }
            catch (Exception)
            {

                throw;
            }

        }
      /*  [HttpGet("{id}", Name = "GetUByID")]
        public IQueryable<Employee_Site> GetByEmployeAsync1(Guid id)
        {
            try
            {
                return _context.Employees_Sites.Where(u => u.Employee_SiteId == id);

            }
            catch (Exception)
            {

                throw;
            }

        }*/




        // PUT: api/Employee_Site/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee_Site([FromRoute] Guid id, [FromBody] Employee_Site employee_Site)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee_Site.IdEmployee_Site)
            {
                return BadRequest();
            }

            _context.Entry(employee_Site).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Employee_SiteExists(id))
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

         // POST: api/Employee_Site
          [HttpPost]
          public async Task<IActionResult> PostEmployee_Site([FromBody] Employee_Site employee_Site)
          {
              if (!ModelState.IsValid)
              {
                  return BadRequest(ModelState);
              }

              _context.Employees_Sites.Add(employee_Site);
            try
            {
                await _context.SaveChangesAsync();
            }

            catch (Exception ex) {
                throw ex;
            }

            //catch (DbUpdateException)
            //{
            //    if (Employee_SiteExists(employee_Site.EmployeeId))
            //    {
            //        return new StatusCodeResult(StatusCodes.Status409Conflict);
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return CreatedAtAction("GetEmployee_Site", new { id = employee_Site.IdEmployee_Site }, employee_Site);
          }


      





        // DELETE: api/Employee_Site/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee_Site([FromRoute] Guid id)
        {
           
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                //first or default retourne le premiere enregistrement where e.id=id sinon return null
                var employee_Site = _context.Employees_Sites.FirstOrDefault(e => e.IdEmployee_Site == id);
                if (employee_Site == null)
                {
                    return NotFound();
                }

                _context.Employees_Sites.Remove(employee_Site);
                SaveChanges(_context);

                return Ok(employee_Site);
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

        private bool Employee_SiteExists(Guid id)
        {
            return _context.Employees_Sites.Any(e => e.IdEmployee_Site == id);
        }
    }
}