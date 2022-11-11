using BGlobalCars.Application.Vehicles.ViewModels.Vehicles;
using MediatR;

namespace BGlobalCars.Application.Vehicles.Requests
{
    public class GetAllVehiclesRequest : IRequest<List<VehicleViewModel>>
    {
    }
}
