using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PointOfSale.Application.Interfaces;
using PointOfSale.Application.Services;
using System.Reflection;

namespace PointOfSale.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            services.AddScoped<IPasswordHashService, PasswordHashService>();
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }
    }
}
