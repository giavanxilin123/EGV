using System.Reflection;
using EGV.Business.Interfaces;
using EGV.Business.Services;
using EGV.DataAccessor.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace EGV.Business
{
    public static class ServiceRegister
    {
        public static void AddBusinessLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IBaseRepository<Category>, BaseRepository<Category>>();
            services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}