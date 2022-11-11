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
        private readonly IRepository<Brand> _brandRepository;

        public AllVehicleRenderHandler(IRepository<Vehicle> vehicleRepository, IRepository<Brand> brandRepository)
        {
            _vehicleRepository = vehicleRepository;
            _brandRepository = brandRepository;
        }

        public async Task<VehicleListViewModel> Handle(RenderVehicleListRequest request, CancellationToken cancellationToken)
        {
            var brandList = (await _brandRepository.GetAll(cancellationToken)).Select(b =>
                new SelectListItem(b.Name, b.Id.ToString())
            ).ToList();
            var vehicleList = (await _vehicleRepository.GetAll(cancellationToken)).Select(v =>
                v.Adapt<VehicleViewModel>()
            ).ToList();
            return new VehicleListViewModel(brandList, vehicleList);
        }
    }
}
