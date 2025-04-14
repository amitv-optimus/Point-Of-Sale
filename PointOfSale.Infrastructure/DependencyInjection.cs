using Microsoft.Extensions.DependencyInjection;

namespace PointOfSale.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            // Add your infrastructure services here
            // e.g., services.AddTransient<IYourService, YourService>();
            return services;
        }
    }
}
