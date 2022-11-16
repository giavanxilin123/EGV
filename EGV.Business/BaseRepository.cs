using System.Linq.Expressions;
using EGV.Business.Interfaces;
using EGV.DataAccessor.Data;
using Microsoft.EntityFrameworkCore;

namespace EGV.Business
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<T> Entities => _dbContext.Set<T>();

        public async Task<T> GetById(int id) => await _dbContext.Set<T>().FindAsync(id);
        public async Task<IEnumerable<T>> GetAll() => await _dbContext.Set<T>().ToListAsync();
        public async Task<T> Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }
        public async Task<T> Update(T entity)
        {
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            return entity;
        }
        public async Task<T> Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return entity;
        }
        public async Task<T> GetByAsync( Expression<Func<T, bool>> filter = null, string includeProperties = "")
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.FirstOrDefaultAsync(filter);
        }
    }
}