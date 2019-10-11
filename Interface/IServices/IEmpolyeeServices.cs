using ProjectPFE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPFE.Interface.IServices
{
    public interface IEmpolyeeServices
    {
        Task<Employee> AddAsync(Employee entity);
        Task<bool> DeleteAsync(string id);
        IQueryable<Employee> GetAllAsync();
        Task<Employee> GetByIdAsync(string id);
        Task<bool> UpdateAsync(string id, Employee entity);
    }
}
