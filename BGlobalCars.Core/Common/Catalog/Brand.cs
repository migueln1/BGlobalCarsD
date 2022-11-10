using System.ComponentModel.DataAnnotations;

namespace BGlobalCars.Core.Common
{
    public class Brand : BaseEntity<int>
    {
        [MaxLength(60)]
        public string Name { get; set; } = "No Brand";
    }
}
