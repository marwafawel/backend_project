using ProjectPFE.Interface;
using ProjectPFE.Interface.IRepositories;
using ProjectPFE.Interface.IServices;
using ProjectPFE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPFE.Services
{
    public class EmployeeServices: IEmpolyeeServices

    {
        protected readonly IEmployeeRepository _EmployeeRepository;

        public EmployeeServices(IEmployeeRepository EmployeeRepository)
        {
            _EmployeeRepository= EmployeeRepository;
        }


        public async Task<Employee> AddAsync(Employee entity)
        {
            var createdEntity = await _EmployeeRepository.AddAsync(entity);
            //  await _BaseRepository.Sav();
            return createdEntity;
        }

        public async Task<bool> DeleteAsync(string id)
        {

            await _EmployeeRepository.DeleteAsync(id);
            return (await GetByIdAsync(id) is null) ? true : false;

        }
        //Done
        public IQueryable<Employee> GetAllAsync()
        {
            return _EmployeeRepository.GetAllAsync();

        }
        //Done
        public async Task<Employee> GetByIdAsync(string id)
        {
            return await _EmployeeRepository.GetByIdAsync(id);

        }
        //Done
        public async Task<bool> UpdateAsync(string id, Employee entity)
        {
            await _EmployeeRepository.UpdateAsync(id, entity);
            var Update = await GetByIdAsync(id);
            return true;
            //return (Update.DateModification >= entity.DateModification) ? true : false;
        }
    }
}
