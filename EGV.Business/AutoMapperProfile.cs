using EGV.Contracts.Dtos.Category;
using EGV.DataAccessor.Entities;

namespace EGV.Business
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            FromDataAccessorLayer();
            FromPresentationLayer();
        }

        private void FromPresentationLayer()
        {

        }

        private void FromDataAccessorLayer()
        {
            CreateMap<Category, CategoryCreateDto>()
                .ReverseMap();
            CreateMap<CategoryDto, Category>()
                .ReverseMap();
        }
    }
}