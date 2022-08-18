using FrameworkExample.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace FrameworkExample.Core.DataAccess.EntityFramework
{
    public abstract class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public TEntity Add(TEntity entity)
        {
            using (var _context = new TContext())
            {
                var addedEntity = _context.Entry<TEntity>(entity);
                addedEntity.State = EntityState.Added;
                _context.SaveChanges();
                return entity; 
            }
        }

        public void Delete(TEntity entity)
        {
            using (var _context = new TContext())
            {
                var updatedEntity = _context.Entry<TEntity>(entity);
                updatedEntity.State = EntityState.Deleted;
                _context.SaveChanges(); 
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var _context = new TContext())
            {
                var updatedEntity = _context.Entry<TEntity>(entity);
                updatedEntity.State = EntityState.Modified;
                _context.SaveChanges();
                return entity; 
            }
        }


        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var _context = new TContext())
            {
                return _context.Set<TEntity>().AsNoTracking().SingleOrDefault(filter ?? (x => true)); 
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var _context = new TContext())
            {
                return _context.Set<TEntity>().Where(filter ?? (x => true)).AsNoTracking().ToList(); 
            }
        }

        public TEntity GetWithIncludes(Expression<Func<TEntity, bool>> filter = null, List<Expression<Func<TEntity, object>>> includes = null)
        {
            using (var _context = new TContext())
            {
                var query = _context.Set<TEntity>().AsQueryable();

                if (includes != null)
                    foreach (var include in includes)
                        query = query.Include(include);

                return query.AsNoTracking().SingleOrDefault(filter); 
            }
        }

        public List<TEntity> GetListWithIncludes(Expression<Func<TEntity, bool>> filter = null, List<Expression<Func<TEntity, object>>> includes = null)
        {
            using (var _context = new TContext())
            {
                var query = _context.Set<TEntity>().Where(filter).AsQueryable();

                if (includes != null)
                    foreach (var include in includes)
                        query = query.Include(include);

                return query.AsNoTracking().ToList(); 
            }
        }


    }
}
