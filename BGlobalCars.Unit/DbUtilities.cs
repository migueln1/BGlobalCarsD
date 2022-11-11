using BGlobalCars.Infrastructure.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BGlobalCars.Unit
{
    public static class DbUtilities
    {
        public static DbContextOptions<BGlobalDbContext> TestDbContextOptions()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<BGlobalDbContext>()
                .UseInMemoryDatabase("BGlobalMemory")
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }
    }
}
