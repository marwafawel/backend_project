using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectPFE.Interface.IController;
using ProjectPFE.Interface.IRepositories;
using ProjectPFE.Interface.IServices;
using ProjectPFE.Models;

using System.Web.Http.Cors;
using Microsoft.AspNetCore.Authorization;
using ProjectPFE.Models.DBContext;

namespace ProjectPFE.Controllers
{
   // [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SiteController : ControllerBase, ISiteController
    {
        private readonly ISiteServices _ServicesSite;
        private readonly ApplicationContext _context;

        public SiteController(ISiteServices servicesite, ApplicationContext context)
        {
            _ServicesSite = servicesite;
            _context = context;
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSiteAsync([FromRoute] Guid id)
        {
            try
            {
                return Ok(await _ServicesSite.DeleteAsync(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpGet]
        public IEnumerable<Site> GetAllSites()
        {
            return _ServicesSite.GetAllAsync();

        }

        [Route("{id}")]
        [HttpGet]

        public async Task<IActionResult> GetSiteAsync([FromRoute] Guid id)
        {

            try
            {
                return Ok(await _ServicesSite.GetByIdAsync(id));
            }
            catch (Exception)
            {
                return NotFound();

            }
        }
        
        [Route("employee/{employeeId}")]
        [HttpGet]
        public IQueryable<Site> GetByEmployeAsync(string employeeId)
        {
            try
            {
                var result = from Sites in _context.Sites
                             join Employees_Sites in _context.Employees_Sites on Sites.SiteId equals Employees_Sites.SiteId
                             where Employees_Sites.employeeId == employeeId
                             select Sites;
                return result;
                // return _context.Vehicules.Where(u => u.Site_Vehicule == siteId);

            }
            catch (Exception)
            {

                throw;
            }

        }

        //POST : api/site
        [HttpPost]
        public async Task<IActionResult> PostSiteAsync([FromBody] Site site)
        {
            var createdEntity = await _ServicesSite.AddAsync(site);
            return CreatedAtAction(nameof(GetSiteAsync), new { id = createdEntity.SiteId }, createdEntity);
        }



        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(Guid id, [FromBody] Site site)
        {
            // TODO: Add an null id detection
            try
            {
                await _ServicesSite.UpdateAsync(id, site);

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }


    }
}