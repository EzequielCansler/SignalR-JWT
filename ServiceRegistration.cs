using BLL.Services;
using DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            // Registro de servicios y repositorios
            services.AddScoped<UserService>();
            services.AddScoped<UserRepository>();
        }
    }
}
