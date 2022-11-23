using EGV.Business.Interfaces;
using EGV.Contracts.Dtos.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EGV.Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryCreateDto categoryCreateDto)
        {
            var categoryAdd = await _categoryService.AddAsync(categoryCreateDto);
            return Ok(categoryAdd);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var category = await _categoryService.GetAllAsync();
            return Ok(category);
        }
    }
}