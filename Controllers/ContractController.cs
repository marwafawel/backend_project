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
    public class ContractController : ControllerBase, IContractController
    {
        private readonly IContractServices _ServicesContract;
        private readonly ApplicationContext _context;
        #region Constructeur
        public ContractController(IContractServices servicecontract, ApplicationContext context)
        {
            _ServicesContract = servicecontract;
            _context = context;
        }
        #endregion
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContractAsync([FromRoute] Guid id)
        {
            try
            {
                return Ok(await _ServicesContract.DeleteAsync(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpGet]
        public IEnumerable<Contract> GetAllContracts()
        {
            return _ServicesContract.GetAllAsync();
        }
        [Route("{id}")]
        [HttpGet]

        public async Task<IActionResult> GetContractAsync([FromRoute] Guid id)
        {
            try
            {
                return Ok(await _ServicesContract.GetByIdAsync(id));
            }
            catch (Exception)
            {
                return NotFound();

            }
        }
        [HttpPost]
        public async Task<IActionResult> PostContractAsync([FromBody] Contract contract)
        {
            var createdEntity = await _ServicesContract.AddAsync(contract);
            return CreatedAtAction(nameof(GetContractAsync), new { id = createdEntity.ContractId }, createdEntity);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Contract contract)
        {
            try
            {
                await _ServicesContract.UpdateAsync(id, contract);

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("vehicule/{VehiculeId}")]
        public Contract GetByVehiculeIdAsync(Guid VehiculeId)
        {
            try
            {
                Contract contrat = _context.Contrats.FirstOrDefault(u => u.VehiculeId == VehiculeId);
                return contrat;
            }
            catch (Exception e)
            {
                throw;
            }

        }
    }
}