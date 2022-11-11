using BGlobalCars.Application.Vehicles.Requests;
using BGlobalCars.Core.Abstractions;
using BGlobalCars.Core.VehicleAggregate;
using BGlobalCars.SharedKernel.LayerReponses;
using Mapster;
using MediatR;
using OneOf;

namespace BGlobalCars.Application.Vehicles.Handlers
{
    public class AddVehicleHandler : IRequestHandler<AddVehicleRequest, OneOf<Vehicle, SQLError>>
    {
        private readonly IRepository<Vehicle> _repository;

        public AddVehicleHandler(IRepository<Vehicle> repository)
        {
            _repository = repository;
        }

        public async Task<OneOf<Vehicle, SQLError>> Handle(AddVehicleRequest request, CancellationToken cancellationToken) =>
            await _repository.TryAdd(request.Adapt<Vehicle>(), cancellationToken);

    }
}
