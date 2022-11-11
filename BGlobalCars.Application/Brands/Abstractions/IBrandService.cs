using Microsoft.AspNetCore.Mvc.Rendering;

namespace BGlobalCars.Application.Brands.Abstractions
{
    public interface IBrandService
    {
        Task<List<SelectListItem>> GetBrandOptions(CancellationToken ct);
    }
}
