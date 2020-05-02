using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DevskillSystem.data
{
    public interface IRepository<TEntity, TKey, TContext>
        where TEntity : class, IEntity<TKey>
        where TContext : DbContext
    {
        public void Add(TEntity entity);
        public void Remove(TKey id);
        public void Remove(TEntity entityToDelete);
        public void Remove(Expression<Func<TEntity, bool>> filter);
        public void Edit(TEntity entityToUpdate);
        public int GetCount(Expression<Func<TEntity, bool>> filter = null);
        public IList<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        public IList<TEntity> GetAll();
        public TEntity GetById(TKey id);

        public (IList<TEntity> data, int total, int totalDisplay) Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);

        public (IList<TEntity> data, int total, int totalDisplay) GetDynamic(
            Expression<Func<TEntity, bool>> filter = null,
            string orderBy = null,
            string includeProperties = "", int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);

        public IList<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", bool isTrackingOff = false);

        public IList<TEntity> GetDynamic(Expression<Func<TEntity, bool>> filter = null,
            string orderBy = null,
            string includeProperties = "", bool isTrackingOff = false);
    }

}