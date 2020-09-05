using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MovieCollection.Core.Concrete;

namespace MovieCollection.Core.Interface
{
    public interface IEditable
    {
        void Save();

        Task SaveAsync();
    }
    
    public interface ICreate<in TEntity> : IEditable
    {
        void Create(TEntity entity);
    }

    public interface IReadCollection<TEntity, in TFilter>
        where TFilter : IPagination
    {
        Selection<TEntity> Read(TFilter filter);
        
        Task<Selection<TEntity>> ReadAsync(TFilter filter);
    }
    
    public interface IRead<TEntity, in TFilter, in TKey> : IReadCollection<TEntity, TFilter>
        where TFilter : IPagination
    {
        TEntity Read(TKey id);

        List<TEntity> Read(Expression<Func<TEntity, bool>> filter);
        
        Task<TEntity> ReadAsync(TKey id);

        Task<List<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> filter);

        bool Exists(TKey id);

        Task<bool> ExistsAsync(TKey id);
    }

    public interface IUpdate<in TEntity> : IEditable
    {
        void Update(TEntity entity);
    }

    public interface IDelete<in TEntity> : IEditable
    {
        void Delete(TEntity entity);
    }

    public interface IRepository<TEntity, in TFilter, in TKey>
        : ICreate<TEntity>,
          IRead<TEntity, TFilter, TKey>,
          IUpdate<TEntity>,
          IDelete<TEntity>
        where TFilter: IFilter
    {
        
    }
}
