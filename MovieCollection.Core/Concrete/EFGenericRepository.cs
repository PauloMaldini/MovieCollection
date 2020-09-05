using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieCollection.Core.Interface;

namespace MovieCollection.Core.Concrete
{
    public class EFGenericRepository<TEntity, TFilter, TKey> 
         : IRepository<TEntity, TFilter, TKey>
            where TEntity : class
            where TFilter : IFilter
    {
        protected DbSet<TEntity> DbSet { get; }
        protected DbContext DbContext { get; }
        protected IQueryable<TEntity> BaseQuery => GetBaseQuery();

        protected EFGenericRepository(DbContext context)
        {
            DbContext = context;
            DbSet = DbContext.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public TEntity Read(TKey id)
        {
            return DbSet.Find(id);
        }

        public List<TEntity> Read(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<TEntity> ReadAsync(TKey id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await BaseQuery
                         .Where(filter)
                         .ToListAsync();
        }

        public bool Exists(TKey id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsAsync(TKey id)
        {
            throw new NotImplementedException();
        }

        public Selection<TEntity> Read(TFilter filter)
        {
            throw new NotImplementedException();
        }

        public async Task<Selection<TEntity>> ReadAsync(TFilter filter)
        {
            var totalCount = await BaseQuery.CountAsync();
            var filtered = AddFilter(BaseQuery, filter);
            var sorted = AddSorting(filtered, filter.OrderBy);
            var filteredCount = await sorted.CountAsync();
            var items = filter.PageIndex == null ? sorted
                        : sorted.Skip((int)(filter.PageIndex * filter.PageSize))
                                  .Take((int)filter.PageSize);

            return new Selection<TEntity>
            {
                Items = await items.ToListAsync(),
                FilteredCount = filteredCount,
                TotalCount = totalCount
            };
        }

        public void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        protected virtual IQueryable<TEntity> GetBaseQuery()
        {
            return DbSet.AsQueryable();
        }

        protected virtual IQueryable<TEntity> AddFilter(IQueryable<TEntity> query, TFilter filter)
        {
            return query;
        }

        protected virtual IQueryable<TEntity> AddSorting(IQueryable<TEntity> query, string orderBy)
        {
            return !string.IsNullOrEmpty(orderBy) ? query.OrderBy(orderBy) : query; 
        }

        public void Save()
        {
            DbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}
