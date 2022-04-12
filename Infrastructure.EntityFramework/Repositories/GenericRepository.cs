using Application.Utilities.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.EntityFramework
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private Context _context;

        public GenericRepository(Context context)
        {
            _context = context;
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate) => _context.Set<TEntity>().Any(predicate);

        public TEntity GetById(params object[] keyValues) => _context.Set<TEntity>().Find(keyValues);

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = null)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (order != null)
            {
                query = order(query);
            }

            return query.ToList();
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate) => _context.Set<TEntity>().FirstOrDefault(predicate);

        public IEnumerable<TEntity> FindByIncluding(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return FindByIncluding(predicate, string.Empty, includeProperties);
        }

        public IEnumerable<TEntity> FindByIncluding(Expression<Func<TEntity, bool>> predicate, string includeProperitesString, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            if (!string.IsNullOrEmpty(includeProperitesString))
            {
                query = query.Include(includeProperitesString);
            }

            return query.Where(predicate).AsQueryable().ToList();
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().AddAsync(entity);

            _context.SaveChanges();
        }

        public TEntity AddReturningEntity(TEntity entity)
        {
            var entityEntry = _context.Set<TEntity>().Add(entity);

            _context.SaveChanges();

            return entityEntry.Entity;
        }

        public void AddRange(IEnumerable<TEntity> entities) => _context.Set<TEntity>().Iterate(e => Add(e));

        public void Delete(int id)
        {
            TEntity getEntity = GetById(id);

            Delete(getEntity);
        }

        public void Delete(TEntity entity)
        {
            var entry = _context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                _context.Set<TEntity>().Attach(entity);
            }

            _context.Set<TEntity>().Remove(entity);

            _context.SaveChanges();
        }

        public void DeleteRange(IEnumerable<TEntity> entities) => entities.Iterate(e => Delete(e));

        public void Update(TEntity entity)
        {
            var keyAttributeProperty = typeof(TEntity).GetProperties().Select(pi => new { Property = pi, Attribute = pi.GetCustomAttributes(typeof(KeyAttribute), true).FirstOrDefault() as KeyAttribute }).Where(x => x.Attribute != null).FirstOrDefault();
            object id = null;

            if (keyAttributeProperty != null)
            {
                id = keyAttributeProperty.Property.GetValue(entity);
            }
            else
            {
                id = entity.GetType().GetProperty("Id").GetValue(entity);
            }

            TEntity getCurrentEntity = GetById(id);
            var getCurrentEntryContext = _context.Entry(getCurrentEntity);
            getCurrentEntryContext.CurrentValues.SetValues(entity);

            _context.SaveChanges();
        }

        public void UpdateRange(IEnumerable<TEntity> entities) => entities.Iterate(e => Update(e));

        public void Refresh(TEntity entity) => _context.Entry(entity).Reload();
    }
}
