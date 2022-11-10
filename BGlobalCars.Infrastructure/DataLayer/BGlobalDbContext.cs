using BGlobalCars.Core.Common;
using BGlobalCars.Core.VehicleAggregate;
using Microsoft.EntityFrameworkCore;

namespace BGlobalCars.Infrastructure.DataLayer
{
    public class BGlobalDbContext : DbContext
    {
        public BGlobalDbContext(DbContextOptions options)
            :base(options)
        {}
        public BGlobalDbContext()
        {}

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}
