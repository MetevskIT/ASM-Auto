using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Models.Products.Ledlights
{
    public class LedlightsPower
    {
        [Key]
        public int LedlightsPowerId { get; set; }

        [Required]
        public string LedlightPower { get; set; } = null!;
    }
}
