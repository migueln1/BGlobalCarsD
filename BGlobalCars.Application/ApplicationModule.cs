using BGlobalCars.Infrastructure;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BGlobalCars.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplicationConfig(
            this IServiceCollection services, IConfiguration config)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddInfrastructureConfig(config);

            return services;
        }
    }
}