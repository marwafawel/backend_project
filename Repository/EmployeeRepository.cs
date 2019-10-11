using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ProjectPFE.Interface;
using ProjectPFE.Interface.IRepositories;
using ProjectPFE.Models;
using ProjectPFE.Models.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectPFE.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        #region Private

        private readonly ApplicationContext _dbContext;
        #endregion

        #region Constructor
        public EmployeeRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion
        public async Task<Employee> AddAsync(Employee entity)
        {
            try
            {
                var now = DateTime.Now;
                entity.DateModification = now;

                // entity.DateModification = now;
                _dbContext.Set<Employee>().Add(entity);
                await _dbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task DeleteAsync(string id)
        {
            try
            {
                var entity = await GetByIdAsync(id);
                _dbContext.Set<Employee>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IQueryable<Employee> GetAllAsync()
        {
            try
            {
                return _dbContext.Set<Employee>();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<Employee> GetByIdAsync(string id)
        {
            try
            {
                return await _dbContext.Set<Employee>().FindAsync(id);

            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task UpdateAsync(string id, Employee entity)
        {
            try
            {




                entity.DateModification = DateTime.Now;
                _dbContext.Set<Employee>().Update(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public IQueryable<Employee> GetBy(Expression<Func<Employee, bool>> predicate)
        {
            try
            {
                return _dbContext.Set<Employee>().Where(predicate);

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
