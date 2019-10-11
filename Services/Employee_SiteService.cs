using ProjectPFE.Interface.IRepositories;
using ProjectPFE.Interface.IServices;
using ProjectPFE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPFE.Services
{
    public class Employee_SiteService:IEmploye_SiteService
    {
        protected readonly IEmployee_SiteRepository _Employee_SiteRepository;


        public Employee_SiteService(IEmployee_SiteRepository Employee_SiteRepository)
        {
            _Employee_SiteRepository = Employee_SiteRepository;
        }

        public async Task<Employee_Site> AddAsync(Employee_Site entity)
        {
            var createdEntity = await _Employee_SiteRepository.AddAsync(entity);
            //  await _BaseRepository.Sav();
            return createdEntity;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {

            await _Employee_SiteRepository.DeleteAsync(id);
            return (await GetByIdAsync(id) is null) ? true : false;

        }
        public IQueryable<Employee_Site> GetAllAsync()
        {
            return _Employee_SiteRepository.GetAllAsync();

        }
        public async Task<Employee_Site> GetByIdAsync(Guid id)
        {
            return await _Employee_SiteRepository.GetByIdAsync(id);

        }
        //Done
        public async Task<bool> UpdateAsync(Guid id, Employee_Site entity)
        {
            await _Employee_SiteRepository.UpdateAsync(id, entity);
            var Update = await GetByIdAsync(id);
            return true;
            //return (Update.DateModification >= entity.DateModification) ? true : false;
        }


    }
   
}
