using BGlobalCars.Application.Brands.Abstractions;
using BGlobalCars.Core.Abstractions;
using BGlobalCars.Core.Common;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BGlobalCars.Application.Brands
{
    public class BrandService : IBrandService
    {
        private readonly IRepository<Brand> _brandRepository;

        public BrandService(IRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<List<SelectListItem>> GetBrandOptions(CancellationToken ct) =>
            (await _brandRepository.GetAll(ct)).Select(b =>
                new SelectListItem(b.Name, b.Id.ToString())
            ).ToList();
    }
}
