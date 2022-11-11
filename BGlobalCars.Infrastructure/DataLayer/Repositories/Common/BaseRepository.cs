using BGlobalCars.Core.Abstractions;
using BGlobalCars.SharedKernel.LayerReponses;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OneOf;

namespace BGlobalCars.Infrastructure.DataLayer.Repositories.Common
{
    public abstract class BaseRepository<T> : IRepository<T>
        where T: class
    {
        private readonly BGlobalDbContext _context;
        public BaseRepository(BGlobalDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAll(CancellationToken ct) => 
            await _context.Set<T>().AsNoTracking().ToListAsync(ct);

        public async Task<OneOf<T, SQLError>> TryAdd(T entity, CancellationToken ct)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity, ct);
                await _context.SaveChangesAsync(ct);
                return entity;
            }
            catch (Exception ex)
            {
                return new SQLError() { Message = $"Error adding: {nameof(T)} / Reason: {ex.Message}" };
            }
        }

    }
}
