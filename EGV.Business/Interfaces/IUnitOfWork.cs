using EGV.DataAccessor.Entities;

namespace EGV.Business.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Category> Category { get; }
        IBaseRepository<User> User { get; }
        IBaseRepository<Product> Product { get; }
        Task SaveAsync();
    }
}