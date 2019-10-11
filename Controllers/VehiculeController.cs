using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectPFE.Interface.IController;
using ProjectPFE.Interface.IServices;
using ProjectPFE.Models;
using ProjectPFE.Models.DBContext;

namespace ProjectPFE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VehiculeController : ControllerBase, IVehiculeController
    {
        private readonly IVehiculeServices _ServicesVehicule;
        private readonly ApplicationContext _context;
        #region Constructeur
        public VehiculeController(IVehiculeServices servicevehicule, ApplicationContext context)
        {
            _ServicesVehicule = servicevehicule;
            _context = context;
        }
        #endregion

        [HttpGet]
        public IEnumerable<Vehicule> GetAllVehicules()
        {
            return _ServicesVehicule.GetAllAsync();
        }
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetVehiculeAsync([FromRoute] Guid id)
        {
            try
            {
                return Ok(await _ServicesVehicule.GetByIdAsync(id));
            }
            catch (Exception)
            {
                return NotFound();

            }
        }

        [Route("site/{siteId}")]
        [HttpGet]
        public IQueryable<Vehicule> GetBySiteAsync(Guid siteId)
        {
            try
            {
                var result = from Vehicules in _context.Vehicules
                             join Employees_Vehicules in _context.Employees_Vehicules on Vehicules.VehiculeId equals Employees_Vehicules.VehiculeId
                             where Employees_Vehicules.SiteId == siteId
                             select Vehicules;
                return result;
                // return _context.Vehicules.Where(u => u.Site_Vehicule == siteId);

            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public async Task<IActionResult> PostVehiculeAsync([FromBody] Vehicule vehicule)
        {
            var createdEntity = await _ServicesVehicule.AddAsync(vehicule);
            return CreatedAtAction(nameof(GetVehiculeAsync), new { id = createdEntity.VehiculeId }, createdEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Vehicule vehicule)
        {
            try
            {
                await _ServicesVehicule.UpdateAsync(id, vehicule);

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehiculeAsync([FromRoute] Guid id)
        {
            try
            {
                return Ok(await _ServicesVehicule.DeleteAsync(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}