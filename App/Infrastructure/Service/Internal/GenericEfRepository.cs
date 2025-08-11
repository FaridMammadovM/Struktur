using Application.Interfaces.IService;
using Infrastructure.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Infrastructure.Service.Internal
{
    public class GenericEfRepository : IGenericEfRepository
    {
        [CompilerGenerated]
        private AppDbContext _003Ccontext_003EP;

        public GenericEfRepository(AppDbContext context)
        {
            _003Ccontext_003EP = context;
            // base._002Ector();
        }

        public async Task<TEntity> GetByIdAsync<TEntity, TKey>(TKey id) where TEntity : class
        {
            return await _003Ccontext_003EP.Set<TEntity>().FindAsync(id);
        }

        public IQueryable<TEntity> GetAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, bool tracking = false, string includeProperties = "") where TEntity : class
        {
            IQueryable<TEntity> queryable = _003Ccontext_003EP.Set<TEntity>();
            if (!string.IsNullOrEmpty(includeProperties))
            {
                queryable = queryable.Include(includeProperties);
            }

            if (filter != null)
            {
                queryable = queryable.Where(filter);
            }

            if (!tracking)
            {
                queryable = queryable.AsNoTracking();
            }

            return queryable;
        }

        public async Task AddAsync<TEntity>(TEntity entity) where TEntity : class
        {
            await _003Ccontext_003EP.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entity) where TEntity : class
        {
            await _003Ccontext_003EP.Set<TEntity>().AddRangeAsync(entity);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            _003Ccontext_003EP.Set<TEntity>().Update(entity);
        }

        public async Task ExecuteUpdateAsync<TEntity>(Expression<Func<TEntity, bool>> filter, Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> setPropertyCalls) where TEntity : class
        {
            await _003Ccontext_003EP.Set<TEntity>().Where(filter).ExecuteUpdateAsync(setPropertyCalls);
        }

        public void Remove<TEntity>(TEntity entity) where TEntity : class
        {
            _003Ccontext_003EP.Set<TEntity>().Remove(entity);
        }

        public async Task<int> CountAsync<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class
        {
            return await GetAsync(filter).CountAsync();
        }

        public async Task<int> Commit()
        {
            return await _003Ccontext_003EP.SaveChangesAsync();
        }

        public async Task<TEntity> FirstOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, bool tracking = false, string includeProperties = "") where TEntity : class
        {
            return await GetAsync(filter, tracking, includeProperties).FirstOrDefaultAsync();
        }

        public async Task<TEntity> LastOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, bool tracking = false, string includeProperties = "") where TEntity : class
        {
            return await GetAsync(filter, tracking, includeProperties).LastOrDefaultAsync();
        }

        public void UpdateRangeAsync<TEntity>(IEnumerable<TEntity> entity) where TEntity : class
        {
            _003Ccontext_003EP.Set<TEntity>().UpdateRange(entity);
        }
    }
}
