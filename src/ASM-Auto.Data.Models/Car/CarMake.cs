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
          
            CarModels = new HashSet<CarModel>();
        }

        [Key]
        public int CarMakeId { get; set; }

        [Required]
        public string? CarMakeText { get; set; }

        public ICollection<CarModel> CarModels { get; set; }
    }
}
