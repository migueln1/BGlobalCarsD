using BGlobalCars.Core.Common;
using BGlobalCars.Core.VehicleAggregate;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BGlobalCars.Infrastructure.DataLayer
{
    public class BGlobalDbContext : DbContext
    {
        public BGlobalDbContext(DbContextOptions options)
            :base(options)
        {}
        public BGlobalDbContext()
        {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}
