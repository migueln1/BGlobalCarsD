namespace BGlobalCars.Application.Vehicles.ViewModels.Vehicles
{
    public class VehicleViewModel
    {
        public int Id { get; set; }
        public string? Plate { get; init; }
        public string? Model { get; init; }
        public int Doors { get; init; }
        public string? Owner { get; init; }
        //public int BrandId { get; init; }
        //TODO mapear marca
        public string Brand { get; init; }
    }
}
