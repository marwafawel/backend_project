using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectPFE.Models;
namespace ProjectPFE.Interface.IRepositories
{
    public interface IEmployee_SiteRepository : IRepositoryBase<Employee_Site>
    {
        IQueryable<Employee_Site> GetByEmployeAsync(string Id);
    }
}
