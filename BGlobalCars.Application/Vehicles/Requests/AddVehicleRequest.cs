using MediatR;

namespace BGlobalCars.Application.Vehicles.Requests
{
    public class AddVehicleRequest : IRequest<int>
    {
        public string? Plate { get; init; }
        public string? Model { get; init; }
        public int Doors { get; init; }
        public string? Owner { get; init; }
        public int BrandId { get; init; }
    }
}
