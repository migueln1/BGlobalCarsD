using BGlobalCars.Core.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace BGlobalCars.Infrastructure.DataLayer.Repositories.Common
{
    public abstract class BaseRepository<T, TId> : IRepository<T, TId>
        where T: class
        where TId: struct
    {
        private readonly DbContext _context;
        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAll(CancellationToken ct) => 
            await _context.Set<T>().ToListAsync(ct);

        public Task<TId> TryAdd(T entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
