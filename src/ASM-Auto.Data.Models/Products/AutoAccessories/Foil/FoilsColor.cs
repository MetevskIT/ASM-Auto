using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Models.Products.Foil
{
    public class FoilsColor
    {
        [Key]
        public int FoilColorId { get; set; }

        [Required]
        public string FoilColor { get; set; } = null!;

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
