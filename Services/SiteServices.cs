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
    public class SiteServices :ISiteServices
    {
        protected readonly ISiteRepository _SiteRepository;

        public SiteServices(ISiteRepository SiteRepository)
        {
            _SiteRepository = SiteRepository;
        }



        public async Task<Site> AddAsync(Site entity)
        {
            var createdEntity = await _SiteRepository.AddAsync(entity);
            //  await _BaseRepository.Sav();
            return createdEntity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {

            await _SiteRepository.DeleteAsync(id);
            return (await GetByIdAsync(id) is null) ? true : false;

        }
        //Done
        public IQueryable<Site> GetAllAsync()
        {
            return _SiteRepository.GetAllAsync();

        }
        //Done
        public async Task<Site> GetByIdAsync(Guid id)
        {
            return await _SiteRepository.GetByIdAsync(id);

        }
        //Done
        public async Task<bool> UpdateAsync(Guid id, Site entity)
        {
            await _SiteRepository.UpdateAsync(id, entity);
            var Update = await GetByIdAsync(id);
           //return true;
            return (Update.DateModification >= entity.DateModification) ? true : false;
        }
    }
}
