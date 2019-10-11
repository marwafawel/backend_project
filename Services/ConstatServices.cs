using ProjectPFE.Interface.IRepositories;
using ProjectPFE.Interface.IServices;
using ProjectPFE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPFE.Services
{
    public class ConstatServices :IConstatServices
    {
        protected readonly IConstatRepository _ConstatRepository;

        public ConstatServices(IConstatRepository ConstatRepository)
        {
            _ConstatRepository = ConstatRepository;
        }


        public async Task<Constat> AddAsync(Constat entity)
        {
            var createdEntity = await _ConstatRepository.AddAsync(entity);
            //  await _BaseRepository.Sav();
            return createdEntity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {

            await _ConstatRepository.DeleteAsync(id);
            return (await GetByIdAsync(id) is null) ? true : false;

        }
        //Done
        public IQueryable<Constat> GetAllAsync()
        {
            return _ConstatRepository.GetAllAsync();

        }
        //Done
        public async Task<Constat> GetByIdAsync(Guid id)
        {
            return await _ConstatRepository.GetByIdAsync(id);

        }
        //Done
        public async Task<bool> UpdateAsync(Guid id, Constat entity)
        {
            await _ConstatRepository.UpdateAsync(id, entity);
            var Update = await GetByIdAsync(id);
            //return true;
            return (Update.DateModification >= entity.DateModification) ? true : false;
        }

    }
}
