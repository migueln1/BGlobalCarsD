using BGlobalCars.Core.Abstractions;
using BGlobalCars.Core.VehicleAggregate;
using BGlobalCars.Infrastructure.DataLayer.Repositories.Common;

namespace BGlobalCars.Infrastructure.DataLayer.Repositories;
public class VehicleRepository : BaseRepository<Vehicle>, IRepository<Vehicle>
{
    public VehicleRepository(BGlobalDbContext context) : base(context)
    {
    }
}
