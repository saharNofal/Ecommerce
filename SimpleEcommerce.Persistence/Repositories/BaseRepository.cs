using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleEcommerce.Application.Contracts.Persistence;
using System.Linq.Expressions;


namespace SimpleEcommerce.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly EcommerceDbContext _dbContext;

        public BaseRepository(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

      
        public async Task<List<T>> FindByAsnc(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);

            return entity;
        }

        public void Add(T entity)
        {
            EntityEntry dbEntityEntry = _dbContext.Entry<T>(entity);
            _dbContext.Set<T>().Add(entity);
        }

      


        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

        }
        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);

        }
        public async Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
            }

        }
    }
}
