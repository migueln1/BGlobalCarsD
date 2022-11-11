using BGlobalCars.Application.Vehicles.Requests;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BGlobalCars.Web.Models.Vehicles
{
    public record AddVehicleViewModel(List<SelectListItem> BrandList, AddVehicleRequest AddVehicleModel);
    //public class AddVehicleViewModel
    //{
    //    public int MyProperty { get; set; }
    //}
}
