using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Interfaces.IService
{
    public interface IGenericEfRepository
    {
        Task<TEntity> GetByIdAsync<TEntity, TKey>(TKey id) where TEntity : class;

        IQueryable<TEntity> GetAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, bool tracking = false, string includeProperties = "") where TEntity : class;

        Task AddAsync<TEntity>(TEntity entity) where TEntity : class;

        Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entity) where TEntity : class;

        void Update<TEntity>(TEntity entity) where TEntity : class;

        Task ExecuteUpdateAsync<TEntity>(Expression<Func<TEntity, bool>> filter, Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> setPropertyCalls) where TEntity : class;

        void Remove<TEntity>(TEntity entity) where TEntity : class;

        Task<int> CountAsync<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class;

        Task<int> Commit();

        Task<TEntity> FirstOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, bool tracking = true, string includeProperties = "") where TEntity : class;

        Task<TEntity> LastOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, bool tracking = true, string includeProperties = "") where TEntity : class;

        void UpdateRangeAsync<TEntity>(IEnumerable<TEntity> entity) where TEntity : class;
    }
}
