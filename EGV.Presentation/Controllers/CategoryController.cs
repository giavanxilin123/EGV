using EGV.Business.Interfaces;
using EGV.Contracts.Dtos.Category;
using EGV.Contracts.Utils;
using Microsoft.AspNetCore.Mvc;

namespace EGV.Presentation.Controllers
{
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
            var categoryId = Generate.GenerateCategoryId(categoryCreateDto.CategoryName);
            var categoryAdd = _categoryService.AddAsync(categoryCreateDto);
            return Ok(categoryAdd);
        }
    }
}