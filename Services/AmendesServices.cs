using ProjectPFE.Interface.IRepositories;
using ProjectPFE.Interface.IServices;
using ProjectPFE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPFE.Services
{
    public class AmendesServices :IAmendeServices
    {
        protected readonly IAmendeRepository _AmendeRepository;

        public AmendesServices(IAmendeRepository AmendeRepository)
        {
            _AmendeRepository = AmendeRepository;
        }


        public async Task<Amende> AddAsync(Amende entity)
        {
            var createdEntity = await _AmendeRepository.AddAsync(entity);
            //  await _BaseRepository.Sav();
            return createdEntity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {

            await _AmendeRepository.DeleteAsync(id);
            return (await GetByIdAsync(id) is null) ? true : false;

        }
        //Done
        public IQueryable<Amende> GetAllAsync()
        {
            return _AmendeRepository.GetAllAsync();

        }
        //Done
        public async Task<Amende> GetByIdAsync(Guid id)
        {
            return await _AmendeRepository.GetByIdAsync(id);

        }
        //Done
        public async Task<bool> UpdateAsync(Guid id, Amende entity)
        {
            await _AmendeRepository.UpdateAsync(id, entity);
            var Update = await GetByIdAsync(id);
            //return true;
            return (Update.DateModification >= entity.DateModification) ? true : false;
        }




    }
}
