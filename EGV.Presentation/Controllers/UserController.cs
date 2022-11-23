using EGV.Business.Interfaces;
using EGV.DataAccessor.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EGV.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        public UserController
        (
            IUserService userService,
            UserManager<User> userManager 
        )
        {
            _userService = userService;
            _userManager = userManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            var user = new User
                {
                    Id = "1",
                    UserName = "alice",
                    FirstName = "Alice",
                    LastName = "Smith",
                    Gender = "F",
                    IsLogged = true, 
                };
            await _userManager.CreateAsync(user, "Abcd@1234");
            return Ok(user);
        }
    }
}
