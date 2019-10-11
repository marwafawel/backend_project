using Microsoft.AspNetCore.Mvc;
using ProjectPFE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPFE.Interface.IController
{
    public interface IConstatController
    {
        IEnumerable<Constat> GetAllConstats();
        Task<IActionResult> GetConstatAsync([FromRoute] Guid id);
        [HttpPost]
        Task<IActionResult> PostConstatAsync([FromBody] Constat constat);
        Task<IActionResult> DeleteConstatAsync([FromRoute] Guid id);
        Task<IActionResult> Update(Guid id, [FromBody] Constat constat);
    }
}
