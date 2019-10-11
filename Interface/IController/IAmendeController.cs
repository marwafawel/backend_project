using Microsoft.AspNetCore.Mvc;
using ProjectPFE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPFE.Interface.IController
{
    public interface IAmendeController
    {
        IEnumerable<Amende> GetAllAmendes();
        Task<IActionResult> GetAmendeAsync([FromRoute] Guid id);
        [HttpPost]
        Task<IActionResult> PostAmendeAsync([FromBody] Amende amende);
        Task<IActionResult> DeleteAmendeAsync([FromRoute] Guid id);
        Task<IActionResult> Update(Guid id, [FromBody] Amende amende);
    }
}
