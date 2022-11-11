using BGlobalCars.Application.Vehicles.Requests;
using BGlobalCars.Application.Vehicles.ViewModels.Vehicles;
using BGlobalCars.Core.Abstractions;
using BGlobalCars.Core.VehicleAggregate;
using Mapster;
using MediatR;

namespace BGlobalCars.Application.Vehicles.Handlers
{
    public class GetAllVehiclesHandler : IRequestHandler<GetAllVehiclesRequest, List<VehicleViewModel>>
    {
        private readonly IRepository<Vehicle> _repository;

        public GetAllVehiclesHandler(IRepository<Vehicle> repository)
        {
            _repository = repository;
        }

        public async Task<List<VehicleViewModel>> Handle(GetAllVehiclesRequest request, CancellationToken cancellationToken) =>
            (await _repository.GetAll(cancellationToken)).Select(v => v.Adapt<VehicleViewModel>()).ToList();
        
    }
}
