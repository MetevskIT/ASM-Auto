using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Models.Products.Ledlights
{
    public class LedlightsType
    {
        [Key]
        public int LedlightsTypeId { get; set; }

        [Required]
        public string LedlightType { get; set; } = null!;
    }
}
