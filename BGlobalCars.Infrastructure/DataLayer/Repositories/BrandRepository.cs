using BGlobalCars.Core.Abstractions;
using BGlobalCars.Infrastructure.DataLayer.Repositories.Common;
using BGlobalCars.Core.Common;

namespace BGlobalCars.Infrastructure.DataLayer.Repositories
{
    public class BrandRepository : BaseRepository<Brand>, IRepository<Brand>
    {
        public BrandRepository(BGlobalDbContext context) : base(context)
        {

        }
    }
}