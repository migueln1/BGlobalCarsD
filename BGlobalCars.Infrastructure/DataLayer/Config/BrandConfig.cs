using BGlobalCars.Core.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGlobalCars.Infrastructure.DataLayer.Config
{
    public class BrandConfig : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(b => b.CreationDate)
                .HasDefaultValueSql("getDate()");

            builder.HasData(
                new Brand() { Id = 1, Name = "Ford", CreationDate = DateTime.Now },
                new Brand() { Id = 2, Name = "Nissan", CreationDate = DateTime.Now },
                new Brand() { Id = 3, Name = "Toyota", CreationDate = DateTime.Now },
                new Brand() { Id = 4, Name = "Chevrolet", CreationDate = DateTime.Now },
                new Brand() { Id = 5, Name = "BMW", CreationDate = DateTime.Now },
                new Brand() { Id = 6, Name = "Porsche", CreationDate = DateTime.Now }
            );
        }
    }
}
