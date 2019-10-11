using Microsoft.AspNetCore.Mvc;
using ProjectPFE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPFE.Interface.IController
{
    public interface IContractController
    {
        IEnumerable<Contract> GetAllContracts();
        Task<IActionResult> GetContractAsync([FromRoute] Guid id);
        [HttpPost]
        Task<IActionResult> PostContractAsync([FromBody] Contract contract);
        Task<IActionResult> DeleteContractAsync([FromRoute] Guid id);
        Task<IActionResult> Update(Guid id, [FromBody] Contract contract);
    }
}
