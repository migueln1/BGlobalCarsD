using BGlobalCars.Application.Brands.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BGlobalCars.Application.Brands.Handlers
{
    public class GetBrandOptionsRequest : IRequest<List<SelectListItem>> { }
    public class GetBrandOptionsHandler : IRequestHandler<GetBrandOptionsRequest, List<SelectListItem>>
    {
        private readonly IBrandService _brandService;

        public GetBrandOptionsHandler(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<List<SelectListItem>> Handle(GetBrandOptionsRequest request, CancellationToken cancellationToken)
        {
            return await _brandService.GetBrandOptions(cancellationToken);
        }
    }
}
