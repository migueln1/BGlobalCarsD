using System.ComponentModel.DataAnnotations.Schema;

namespace BGlobalCars.Core.Common
{
    public abstract class BaseEntity<T> where T : struct
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; init; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreationDate { get; init; }

        public DateTime? ModificationDate { get; init; }
    }
}
