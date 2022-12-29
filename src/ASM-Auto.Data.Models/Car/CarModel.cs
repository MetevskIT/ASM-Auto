using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM_Auto.Data.Models.Car
{
    public class CarModel
    {
        [Key]
        public int CarModelId { get; set; }

        [Required]
        public string CarModelText { get; set; }

        [ForeignKey(nameof(CarMake))]
        public int CarMakeId { get; set; }

        public CarMake CarMake { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
