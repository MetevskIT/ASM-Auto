using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Models.Car
{
    public class CarMake
    {
        public CarMake()
        {
          
            this.CarModels = new HashSet<CarModel>();
            this.Products = new List<Product>();
        }

        [Key]
        public int CarMakeId { get; set; }

        [Required]
        public string CarMakeText { get; set; } = null!;

        public ICollection<CarModel> CarModels { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
