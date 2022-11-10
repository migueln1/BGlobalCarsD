using BGlobalCars.Core.Abstractions;
using BGlobalCars.Core.VehicleAggregate;
using BGlobalCars.Infrastructure.DataLayer;
using BGlobalCars.Infrastructure.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BGlobalCars.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructureConfig(
            this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<BGlobalDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("BGlobalConnString")));

            services.AddTransient<IRepository<Vehicle, int>, VehicleRepository>();

            return services;
        }
    }
}