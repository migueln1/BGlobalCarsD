using BGlobalCars.Application.Vehicles.Requests;
using BGlobalCars.Application.Vehicles.ViewModels.Vehicles;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BGlobalCars.Application.Vehicles.Responses.Vehicles
{
    public class VehicleListViewModel
    {
        public VehicleListViewModel(
            List<VehicleViewModel> vehicles,
            AddVehicleViewModel vehicleModel)
        {
            Vehicles = vehicles;
            VehicleModel = vehicleModel;
        }
        public AddVehicleViewModel VehicleModel { get; set; }
        public List<VehicleViewModel> Vehicles { get; set; }

    }
}
