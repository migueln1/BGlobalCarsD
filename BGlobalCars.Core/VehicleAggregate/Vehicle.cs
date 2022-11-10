using BGlobalCars.Core.Common;
using System.ComponentModel.DataAnnotations;

namespace BGlobalCars.Core.VehicleAggregate
{
    public class Vehicle : BaseEntity<int>
    {
        public Vehicle() { }

        [Required]
        [MaxLength(8)]
        public string? Plate { get; set; }

        [MaxLength(60)]
        public string? Model { get; set; }

        public int Doors { get; set; }

        [MaxLength(60)]
        public string? Owner { get; set; }

        public int BrandId { get; set; }
        public virtual Brand? Brand { get; init; }

    }
}
