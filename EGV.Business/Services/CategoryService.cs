using AutoMapper;
using EGV.Business.Interfaces;
using EGV.Contracts.Dtos.Category;
using EGV.Contracts.Utils;
using EGV.DataAccessor.Entities;


namespace EGV.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public CategoryService
        (
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CategoryDto> AddAsync(CategoryCreateDto categoryCreateDto){
            var categoryID = Generate.GenerateCategoryId(categoryCreateDto.CategoryName);
            Category category = _mapper.Map<Category>(categoryCreateDto);
            category.CategoryID = categoryID;
            category.IsDeleted = false;
            await _unitOfWork.Category.Add(category);
            await _unitOfWork.SaveAsync();
            CategoryDto categoryDto = _mapper.Map<CategoryDto>(category);
            return categoryDto;
        }

        public async Task<List<CategoryDto>> GetAllAsync(){
            var categories = await _unitOfWork.Category.GetAll();
            return _mapper.Map<List<CategoryDto>>(categories);
        }
    }
}