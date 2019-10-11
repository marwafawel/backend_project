using ProjectPFE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPFE.Interface.IRepositories
{
    public interface IEmployeeRepository 
    {

        Task<Employee> GetByIdAsync(string id);
        IQueryable<Employee> GetAllAsync();
        Task<Employee> AddAsync(Employee entity);
        Task UpdateAsync(string id, Employee entity);
        Task DeleteAsync(string id);
    }
}
