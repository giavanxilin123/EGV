using EGV.Business.Interfaces;
using EGV.DataAccessor.Data;
using EGV.DataAccessor.Entities;

namespace EGV.Business

{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private IBaseRepository<Category> _category;
        private IBaseRepository<User> _user;
        private IBaseRepository<Product> _product;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IBaseRepository<Category> Category => _category ??= new BaseRepository<Category>(_dbContext);
        public IBaseRepository<Product> Product => _product ??= new BaseRepository<Product>(_dbContext);
        public IBaseRepository<User> User => _user ??= new BaseRepository<User>(_dbContext);
        
        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}