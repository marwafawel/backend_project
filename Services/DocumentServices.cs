using ProjectPFE.Interface.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectPFE.Models;
using ProjectPFE.Interface.IRepositories;
using ProjectPFE.Interface.IServices;
using ProjectPFE.Interface;

namespace ProjectPFE.Services
{
    public class DocumentServices :IDocumentServices
    {
        protected readonly IDocumentRepository _DocumentRepository;

        public DocumentServices(IDocumentRepository DocumentRepository)
        {
            _DocumentRepository = DocumentRepository;
        }

        public async Task<Document> AddAsync(Document entity)
        {
            var createdEntity = await _DocumentRepository.AddAsync(entity);
            //  await _BaseRepository.Sav();
            return createdEntity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {

            await _DocumentRepository.DeleteAsync(id);
            return (await GetByIdAsync(id) is null) ? true : false;

        }
        //Done
        public IQueryable<Document> GetAllAsync()
        {
            return _DocumentRepository.GetAllAsync();

        }
        //Done
        public async Task<Document> GetByIdAsync(Guid id)
        {
            return await _DocumentRepository.GetByIdAsync(id);

        }
        /** get doc by vehicule id */

      






        //Done
        public async Task<bool> UpdateAsync(Guid id, Document entity)
        {
            await _DocumentRepository.UpdateAsync(id, entity);
            var Update = await GetByIdAsync(id);
            //return true;
            return (Update.DateModification >= entity.DateModification) ? true : false;
        }
    }
}
