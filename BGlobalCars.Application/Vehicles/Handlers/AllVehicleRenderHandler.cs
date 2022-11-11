using BGlobalCars.Application.Brands.Abstractions;
using BGlobalCars.Application.Vehicles.Requests;
using BGlobalCars.Application.Vehicles.Responses.Vehicles;
using BGlobalCars.Application.Vehicles.ViewModels.Vehicles;
using BGlobalCars.Core.Abstractions;
using BGlobalCars.Core.Common;
using BGlobalCars.Core.VehicleAggregate;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BGlobalCars.Application.Vehicles.Handlers
{
    public class AllVehicleRenderHandler : IRequestHandler<RenderVehicleListRequest, VehicleListViewModel>
    {
        private readonly IRepository<Vehicle> _vehicleRepository;
        private readonly IBrandService _brandService;

        public AllVehicleRenderHandler(IRepository<Vehicle> vehicleRepository, IBrandService brandService)
        {
            _vehicleRepository = vehicleRepository;
            _brandService = brandService;
        }

        public async Task<VehicleListViewModel> Handle(RenderVehicleListRequest request, CancellationToken cancellationToken)
        {
            var brandList = await _brandService.GetBrandOptions(cancellationToken);
            var vehicleList = (await _vehicleRepository.GetAll(cancellationToken)).Select(v =>
                v.Adapt<VehicleViewModel>()
            ).ToList();

            return new VehicleListViewModel(vehicleList, new(brandList,new()));
        }
    }
}
