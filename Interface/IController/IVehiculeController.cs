using Microsoft.AspNetCore.Mvc;
using ProjectPFE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPFE.Interface.IController
{
    public interface IVehiculeController
    {
        IEnumerable<Vehicule> GetAllVehicules();
        Task<IActionResult> GetVehiculeAsync([FromRoute] Guid id);
        [HttpPost]
        Task<IActionResult> PostVehiculeAsync([FromBody] Vehicule vehicule);
        Task<IActionResult> DeleteVehiculeAsync([FromRoute] Guid id);
        Task<IActionResult> Update(Guid id, [FromBody] Vehicule vehicule);
    }
}
