using ProjectPFE.Interface.IRepositories;
using ProjectPFE.Models;
using ProjectPFE.Models.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPFE.Repository
{
    public class Employee_SiteRepository :RepositoryBase<Employee_Site>,IEmployee_SiteRepository
    {
        private readonly ApplicationContext _dbContext;
        public Employee_SiteRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Employee_Site> GetByEmployeAsync(string Id)
        {
            try
            {
                return _dbContext.Employees_Sites.Where(u => u.employeeId == Id);

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
