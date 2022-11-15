using EGV.Business.Interfaces;
using EGV.DataAccessor.Entities;
using Microsoft.EntityFrameworkCore;

namespace EGV.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _userRepository;

        public UserService
        ( 
            IBaseRepository<User> userRepository 
        )
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAllAsync()
        {
            var result = await _userRepository.Entities.ToListAsync();
            return result;
        }
    }
}