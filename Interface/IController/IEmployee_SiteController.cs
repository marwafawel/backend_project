using Microsoft.AspNetCore.Mvc;
using ProjectPFE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPFE.Interface.IController
{
    public interface IEmployee_SiteController
    {
       

        IEnumerable<Employee_Site> GetEmployees_Sites();
        Task<IActionResult> GetEmployee_Site([FromRoute] Guid id); 
        IQueryable<Employee_Site> GetByEmployeAsync(Guid Id);
        Task<IActionResult> PutEmployee_Site([FromRoute] Guid id, [FromBody] Employee_Site employee_Site);
        Task<IActionResult> PostEmployee_Site([FromBody] Employee_Site employee_Site);
        Task<IActionResult> DeleteEmployee_Site([FromRoute] Guid id);
    }
}
