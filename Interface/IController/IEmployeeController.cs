using Microsoft.AspNetCore.Mvc;
using ProjectPFE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPFE.Interface.IController
{
    public interface IEmployeeController
    {
        IEnumerable<Employee> GetAllEmployees();
        Task<IActionResult> GetEmployeeAsync([FromRoute] string id);
        [HttpPost]
        Task<IActionResult> PostEmployeeAsync([FromBody] Employee employee);
        Task<IActionResult> DeleteEmployeeAsync([FromRoute] string id);
        Task<IActionResult> Update(string id, [FromBody] Employee employee);
    }
}
