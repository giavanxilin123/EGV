using EGV.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EGV.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("All")]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }
    }
}
