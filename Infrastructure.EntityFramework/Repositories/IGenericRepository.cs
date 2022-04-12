using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.EntityFramework
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = null);
        TEntity GetById(params object[] keyValues);
        void Add(TEntity entity);
        TEntity AddReturningEntity(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        bool Any(Expression<Func<TEntity, bool>> predicate);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        TEntity Find(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> FindByIncluding(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties);
        IEnumerable<TEntity> FindByIncluding(Expression<Func<TEntity, bool>> predicate, string includePropertiesString,
            params Expression<Func<TEntity, object>>[] includeProperties);
        void Delete(TEntity entity);
        void Delete(int id);
        void DeleteRange(IEnumerable<TEntity> entities);
        void Refresh(TEntity entity);
    }
}
