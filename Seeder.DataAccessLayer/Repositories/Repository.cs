using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Seeder.DataAccessLayer.Context;
using Seeder.DataAccessLayer.Repositories.Interfaces;

namespace Seeder.DataAccessLayer.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected AppDbContext dbContext;

        public Repository(AppDbContext context)
        {
            dbContext = context;
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return dbContext.Set<TEntity>().Where(predicate);
        }

        public virtual Task<TEntity> FindFirst(Expression<Func<TEntity, bool>> predicate)
        {
            return dbContext.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().AsNoTracking();
        }

        public virtual TEntity Get(int id)
        {
            return dbContext.Set<TEntity>().Find(id);
        }

        public virtual Task<TEntity> GetAsync(int id)
        {
            return dbContext.Set<TEntity>().FindAsync(id);
        }

        public virtual void Add(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
        }

        public virtual Task AddAsync(TEntity entity)
        {
            return dbContext.Set<TEntity>().AddAsync(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            dbContext.Set<TEntity>().AddRange(entities);
        }

        public virtual Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            return dbContext.Set<TEntity>().AddRangeAsync(entities);
        }

        public virtual void Update(TEntity entity)
        {
            dbContext.Set<TEntity>().Update(entity);
        }
    }}
