using ProjectPFE.Interface.IRepositories;
using ProjectPFE.Interface.IServices;
using ProjectPFE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPFE.Services
{
    public class VehiculeServices :IVehiculeServices
    {
        protected readonly IVehiculeRepository _VehiculeRepository;

        public VehiculeServices(IVehiculeRepository VehiculeRepository)
        {
            _VehiculeRepository = VehiculeRepository;
        }
        public async Task<Vehicule> AddAsync(Vehicule entity)
        {
            var createdEntity = await _VehiculeRepository.AddAsync(entity);
            //  await _BaseRepository.Sav();
            return createdEntity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {

            await _VehiculeRepository.DeleteAsync(id);
            return (await GetByIdAsync(id) is null) ? true : false;

        }
        //Done
        public IQueryable<Vehicule> GetAllAsync()
        {
            return _VehiculeRepository.GetAllAsync();

        }
        //Done
        public async Task<Vehicule> GetByIdAsync(Guid id)
        {
            return await _VehiculeRepository.GetByIdAsync(id);

        }
        //Done
        public async Task<bool> UpdateAsync(Guid id, Vehicule entity)
        {
            await _VehiculeRepository.UpdateAsync(id, entity);
            var Update = await GetByIdAsync(id);
            //return true;
            return (Update.DateModification >= entity.DateModification) ? true : false;
        }
    }
}
