using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Models.Products.Foil
{
    public class FoilsType
    {
        [Key]
        public int FoilTypeId { get; set; }

        [Required]
        public string FoilType { get; set; } = null!;
    }
}
