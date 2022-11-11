using BGlobalCars.Application.Vehicles.Requests;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BGlobalCars.Application.Vehicles.Responses.Vehicles
{
    public record AddVehicleViewModel(List<SelectListItem> BrandList, AddVehicleRequest NewVehicle);
}
