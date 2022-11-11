using BGlobalCars.Core.VehicleAggregate;
using BGlobalCars.SharedKernel.LayerReponses;
using MediatR;
using OneOf;
using System.ComponentModel.DataAnnotations;

namespace BGlobalCars.Application.Vehicles.Requests
{
    public class AddVehicleRequest : IRequest<OneOf<Vehicle, SQLError>>
    {
        [Required(ErrorMessage = "El campo placa es requerida")]
        [StringLength(8,ErrorMessage = "El campo placa debe tener 8 carácteres",MinimumLength = 8)]
        public string? Plate { get; init; }
        [Required(ErrorMessage = "El campo modelo es requerido")]
        public string? Model { get; init; }
        [Range(1,10,ErrorMessage = "El campo puertas debe tener un valor entre 1 y 10 puertas")]
        public int Doors { get; init; }
        [Required(ErrorMessage = "El campo dueño es requerido")]
        public string? Owner { get; init; }
        public int BrandId { get; init; }
    }
}
