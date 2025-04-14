using PointOfSale.Application;
using PointOfSale.Infrastructure;
using PointOfSale.Persistence;

namespace PointOfSale.WebAPI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebAPIDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDI(configuration).AddPersistenceDI(configuration).AddInfrastructureDI();
            return services;
        }
    }
}
