using BGlobalCars.Core.VehicleAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BGlobalCars.Infrastructure.DataLayer.Config
{

    public class VehicleConfig : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.Property(b => b.CreationDate)
                .HasDefaultValueSql("getDate()");
        }

    }
}
