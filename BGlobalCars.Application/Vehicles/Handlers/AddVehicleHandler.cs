using BGlobalCars.Application.Vehicles.Requests;
using BGlobalCars.Core.Abstractions;
using BGlobalCars.Core.VehicleAggregate;
using Mapster;
using MediatR;

namespace BGlobalCars.Application.Vehicles.Handlers
{
    public class AddVehicleHandler : IRequestHandler<AddVehicleRequest, int>
    {
        private readonly IRepository<Vehicle, int> _repository;

        public AddVehicleHandler(IRepository<Vehicle, int> repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(AddVehicleRequest request, CancellationToken cancellationToken) =>
            await _repository.TryAdd(request.Adapt<Vehicle>(), cancellationToken);

    }
}
