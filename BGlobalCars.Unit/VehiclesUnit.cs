using BGlobalCars.Core.Abstractions;
using BGlobalCars.Core.Common;
using BGlobalCars.Core.VehicleAggregate;
using BGlobalCars.Infrastructure.DataLayer;
using BGlobalCars.Infrastructure.DataLayer.Repositories;
using BGlobalCars.Unit.Utilities;
using FluentAssertions;
using Moq;
namespace BGlobalCars.Unit
{
    public class VehiclesUnit
    {

        [Theory]
        [InlineData("34FRG7V1", "Juan", "Corolla", 1, 4)]
        [InlineData("34FRGKV1", "Jesus", "Corolla", 1, 4)]
        public async Task WhenAllValuesAreValid_VehicleRepository_ShouldCreateVehicle(
            string plate, string owner, string model, int brandId, int doors)
        {
            using (var context = new BGlobalDbContext(DbUtilities.TestDbContextOptions()))
            {
                //Assert
                var vehicleRepository = new Mock<VehicleRepository>(context);
                var vehicle = new Vehicle() { Plate = plate, Owner = owner, Model = model, BrandId = brandId, Doors = doors };
    
                //Act
                var actionResult = await vehicleRepository.Object.TryAdd(vehicle, default);

                //Assert

                actionResult.Match(vehicle => true,
                    SqlError => false).Should().BeTrue();
            }
        }
    }
}