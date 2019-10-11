using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPFE.Interface.IRepositories
{
   // <TEntity >c est class generic 
   //Irepository herite de l interface IEntity
    public interface IRepositoryBase<TEntity> where TEntity :class, IEntity
    {
        //task : single operation that return a value et executer d une maniere asynchrone 
        Task<TEntity> GetByIdAsync(Guid id);
        IQueryable<TEntity> GetAllAsync();
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(Guid id, TEntity entity);
        Task DeleteAsync(Guid id);
        
    }
}
