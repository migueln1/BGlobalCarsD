using BGlobalCars.Core.Abstractions;
using BGlobalCars.Core.VehicleAggregate;
using BGlobalCars.Infrastructure.DataLayer.Repositories.Common;

namespace BGlobalCars.Infrastructure.DataLayer.Repositories;
public class VehicleRepository : BaseRepository<Vehicle, int>, IRepository<Vehicle, int>
{
    public VehicleRepository(BGlobalDbContext context) : base(context)
    {
    }
}
