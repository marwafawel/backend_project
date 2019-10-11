using ProjectPFE.Interface.IRepositories;
using ProjectPFE.Interface.IServices;
using ProjectPFE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPFE.Services
{
    public class ContratServices :IContractServices
    {
        protected readonly IContractRepository _ContractRepository;

        public ContratServices(IContractRepository ContractRepository)
        {
            _ContractRepository = ContractRepository;
        }

        public async Task<Contract> AddAsync(Contract entity)
        {
            var createdEntity = await _ContractRepository.AddAsync(entity);
            //  await _BaseRepository.Sav();
            return createdEntity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {

            await _ContractRepository.DeleteAsync(id);
            return (await GetByIdAsync(id) is null) ? true : false;

        }
        //Done
        public IQueryable<Contract> GetAllAsync()
        {
            return _ContractRepository.GetAllAsync();

        }
        //Done
        public async Task<Contract> GetByIdAsync(Guid id)
        {
            return await _ContractRepository.GetByIdAsync(id);

        }
        //Done
        public async Task<bool> UpdateAsync(Guid id, Contract entity)
        {
            await _ContractRepository.UpdateAsync(id, entity);
            var Update = await GetByIdAsync(id);
            //return true;
            return (Update.DateModification >= entity.DateModification) ? true : false;
        }


    }
}
