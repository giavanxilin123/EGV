using EGV.Contracts.Dtos.Category;
using EGV.DataAccessor.Entities;

namespace EGV.Business.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> AddAsync(CategoryCreateDto categoryCreateDto);
    }
}