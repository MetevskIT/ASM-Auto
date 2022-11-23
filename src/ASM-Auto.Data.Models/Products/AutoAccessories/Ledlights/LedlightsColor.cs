using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Models.Products.Ledlights
{
    public class LedlightsColor
    {
        [Key]
        public int LedlightsColorId { get; set; }

        [Required]
        public string LedlightColor { get; set; } = null!;

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
