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
    public class AmendeController : ControllerBase, IAmendeController
    {
        private readonly IAmendeServices _ServicesAmende;
        private readonly ApplicationContext _context;
        #region Constructeur
        public AmendeController(IAmendeServices serviceAmende, ApplicationContext context)
        {
            _ServicesAmende = serviceAmende;
            _context = context;
        }
        #endregion
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmendeAsync([FromRoute] Guid id)
        {
            try
            {
                return Ok(await _ServicesAmende.DeleteAsync(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpGet]
        public IEnumerable<Amende> GetAllAmendes()
        {
            return _ServicesAmende.GetAllAsync();
        }
        [Route("{id}")]
        [HttpGet]

        public  async Task<IActionResult> GetAmendeAsync([FromRoute] Guid id)
        {

            try
            {
                return Ok(await _ServicesAmende.GetByIdAsync(id));
            }
            catch (Exception)
            {
                return NotFound();

            }
        }


        [Route("site/{siteId}")]
        [HttpGet]
        public IQueryable<Amende> GetBySiteAsync(Guid siteId)
        {
            try
            {
                return _context.Amendes.Where(u => u.siteId == siteId);

            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public async Task<IActionResult> PostAmendeAsync([FromBody] Amende amende)
        {

            try
            {
                var createdEntity = await _ServicesAmende.AddAsync(amende);
                return CreatedAtAction(nameof(GetAmendeAsync), new { id = createdEntity.AmendeId }, createdEntity);
            }
            catch (Exception e)
            {
                return NotFound();

            }
        }
        [HttpPut("{id}")]

        public virtual async Task<IActionResult> Update(Guid id, [FromBody] Amende amende)
        {
            try
            {
                await _ServicesAmende.UpdateAsync(id, amende);

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}