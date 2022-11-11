using BGlobalCars.Application.Vehicles.Requests;
using BGlobalCars.Application.Vehicles.ViewModels.Vehicles;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BGlobalCars.Application.Vehicles.Responses.Vehicles
{
    public class VehicleListViewModel
    {
        public VehicleListViewModel(List<SelectListItem> brandList,
            List<VehicleViewModel> vehicles)
        {
            BrandList = brandList;
            Vehicles = vehicles;
        }
        public List<SelectListItem> BrandList { get; init; }
        public AddVehicleRequest NewVehicle { get; init; }
        public List<VehicleViewModel> Vehicles { get; set; }

    }
}
