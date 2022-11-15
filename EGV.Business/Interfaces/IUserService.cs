using EGV.DataAccessor.Entities;

namespace EGV.Business.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
    }
}