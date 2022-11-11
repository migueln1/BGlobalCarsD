using BGlobalCars.Core.Abstractions;
using BGlobalCars.Core.Common;
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
            var conn = config.GetConnectionString("BGlobalConnString");
            services.AddDbContext<BGlobalDbContext>(options =>
                options.UseSqlServer(conn));

            services.AddTransient<IRepository<Vehicle>, VehicleRepository>();
            services.AddTransient<IRepository<Brand>, BrandRepository>();

            return services;
        }
    }
}