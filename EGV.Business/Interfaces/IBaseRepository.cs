using System.Linq.Expressions;

namespace EGV.Business.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> Entities { get; }
        Task<T> GetById(int id);
        Task<T> GetByAsync(Expression<Func<T, bool>> filter = null, string includeProperties = "");
        Task<IEnumerable<T>> GetAll();
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
    }
}