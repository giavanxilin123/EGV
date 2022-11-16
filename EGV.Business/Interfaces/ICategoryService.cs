using EGV.Contracts.Dtos.Category;

namespace EGV.Business.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDto> AddAsync(CategoryCreateDto categoryCreateDto);
    }
}