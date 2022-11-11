using BGlobalCars.Core.VehicleAggregate;
using BGlobalCars.SharedKernel.LayerReponses;
using MediatR;
using OneOf;

namespace BGlobalCars.Application.Vehicles.Requests
{
    public class AddVehicleRequest : IRequest<OneOf<Vehicle, SQLError>>
    {
        public string? Plate { get; init; }
        public string? Model { get; init; }
        public int Doors { get; init; }
        public string? Owner { get; init; }
        public int BrandId { get; init; }
    }
}
