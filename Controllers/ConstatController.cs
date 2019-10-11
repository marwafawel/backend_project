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

namespace ProjectPFE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ConstatController : ControllerBase, IConstatController
    {

        private readonly IConstatServices _ServicesConstat;
        #region Constructeur
        public ConstatController(IConstatServices serviceConstat)
        {
            _ServicesConstat = serviceConstat;
        }
        #endregion
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConstatAsync([FromRoute] Guid id)
        {
            try
            {
                return Ok(await _ServicesConstat.DeleteAsync(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpGet]
        public IEnumerable<Constat> GetAllConstats()
        {
            return _ServicesConstat.GetAllAsync();
        }
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetConstatAsync([FromRoute] Guid id)
        {
            try
            {
                return Ok(await _ServicesConstat.GetByIdAsync(id));
            }
            catch (Exception)
            {
                return NotFound();

            }
        }
        [HttpPost]

        public async Task<IActionResult> PostConstatAsync([FromBody] Constat constat)
        {
            var createdEntity = await _ServicesConstat.AddAsync(constat);
            return CreatedAtAction(nameof(GetConstatAsync), new { id = createdEntity.ConstatId }, createdEntity);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Constat constat)
        {
            try
            {
                await _ServicesConstat.UpdateAsync(id, constat);

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}