using AutoMapper;
using EGV.Business.Interfaces;
using EGV.Contracts.Dtos.Category;
using EGV.Contracts.Utils;
using EGV.DataAccessor.Entities;


namespace EGV.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IBaseRepository<Category> _categoryRepository;
        private IMapper _mapper;
        public CategoryService
        (
            IBaseRepository<Category> categoryRepository,
            IMapper mapper
        )
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<Category> AddAsync(CategoryCreateDto categoryCreateDto){
            Category category = _mapper.Map<Category>(categoryCreateDto);
            category.CategoryID = Generate.GenerateCategoryId(categoryCreateDto.CategoryName);
            await _categoryRepository.Add(category);
            return category;
        }
    }
}