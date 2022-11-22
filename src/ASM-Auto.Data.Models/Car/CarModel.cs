using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Models.Car
{
    public class CarModel
    {
        public CarModel()
        {
        }

        [Key]
        public int CarModelId { get; set; }

        [Required]
        public string CarModelText { get; set; } = null!;


        [ForeignKey(nameof(CarMake))]
        public int CarMakeId { get; set; } 
        public CarMake CarMake { get; set; } = null!;

    }
}
