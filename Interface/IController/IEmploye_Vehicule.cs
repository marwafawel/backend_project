using Microsoft.AspNetCore.Mvc;
using ProjectPFE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPFE.Interface.IController
{
    public interface IEmploye_Vehicule
    {
        IEnumerable<Conducteur_vehicule> GetEmployees_Vehicules();
        Task<IActionResult> GetConducteur_vehicule([FromRoute] Guid id);
        Task<IActionResult> PutConducteur_vehicule([FromRoute] Guid id, [FromBody] Conducteur_vehicule conducteur_vehicule);
        Task<IActionResult> PostConducteur_vehicule([FromBody] Conducteur_vehicule conducteur_vehicule);
        Task<IActionResult> DeleteConducteur_vehicule([FromRoute] Guid id);
        IQueryable<Conducteur_vehicule> GetByEmployeAsync(Guid VehiculeId);

    }
}
