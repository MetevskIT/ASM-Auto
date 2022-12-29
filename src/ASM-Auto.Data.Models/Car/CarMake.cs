using System.ComponentModel.DataAnnotations;

namespace ASM_Auto.Data.Models.Car
{
    public class CarMake
    {
        [Key]
        public int CarMakeId { get; set; }

        [Required]
        public string CarMakeText { get; set; }

        public ICollection<CarModel> CarModels { get; set; } = new HashSet<CarModel>();
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
