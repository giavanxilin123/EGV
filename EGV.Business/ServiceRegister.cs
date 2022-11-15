using System.Reflection;
using EGV.Business.Interfaces;
using EGV.Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EGV.Business
{
    public static class ServiceRegister
    {
        public static void AddBusinessLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }
    }
}