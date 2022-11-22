using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Models.Products.Ledlights
{
    public class LedlightsFormat
    {
        [Key]
        public int LedlightsFormatId { get; set; }

        [Required]
        public string LedlightFormat { get; set; } = null!;
    }
}
