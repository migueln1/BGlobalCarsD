using BGlobalCars.SharedKernel.LayerReponses;
using OneOf;

namespace BGlobalCars.Core.Abstractions
{
    public interface IRepository<T> 
        where T: class
    {
        Task<IEnumerable<T>> GetAll(CancellationToken ct);
        Task<OneOf<T, SQLError>> TryAdd(T entity, CancellationToken ct);
    }
}
