using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPFE.Interface.IServices
{
    public interface IServicesBase<TEntity> where TEntity : class ,IEntity
    {
        Task <TEntity> AddAsync(TEntity entity);
        Task<bool> DeleteAsync(Guid id);
        IQueryable<TEntity> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid id);
        Task<bool> UpdateAsync(Guid id, TEntity entity);
    }
}
