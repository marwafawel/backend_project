using ProjectPFE.Interface;
using ProjectPFE.Interface.IRepositories;
using ProjectPFE.Models.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectPFE.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class,IEntity
    {      
        #region Private
        
        private readonly ApplicationContext _dbContext;
        #endregion

        #region Constructor
        public RepositoryBase(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Methodes

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            try
            {
                var now = DateTime.Now;
                entity.DateModification = now;
                
               // entity.DateModification = now;
                _dbContext.Set<TEntity>().Add(entity);
                await _dbContext.SaveChangesAsync();
               
                return entity ;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Done
        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var entity = await GetByIdAsync(id);
                _dbContext.Set<TEntity>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Done
        public IQueryable<TEntity> GetAllAsync()
        {
            try
            {
                return _dbContext.Set<TEntity>();
            }
            catch (Exception)
            {

                throw;
            }

        }
        //Done

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            try
            {
                return await _dbContext.Set<TEntity>().FindAsync(id);
               
            }
            catch (Exception)
            {

                throw;
            }

        }
        //Done
        public async Task UpdateAsync(Guid id, TEntity entity)
        {
            try
            {



                
                entity.DateModification = DateTime.Now;
                _dbContext.Set<TEntity>().Update(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

        }


        public  IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return  _dbContext.Set<TEntity>().Where(predicate);

            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

    }
}
