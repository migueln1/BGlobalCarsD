namespace BGlobalCars.Core.Abstractions
{
    public interface IRepository<T, TId> 
        where T: class
        where TId : struct
    {
        Task<IEnumerable<T>> GetAll(CancellationToken ct);
        Task<TId> TryAdd(T entity, CancellationToken ct);
    }
}
