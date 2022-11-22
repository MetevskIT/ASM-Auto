using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Models.Products.Foil
{
    public class FoilsPurpose
    {
        [Key]
        public int FoilPurposeId { get; set; }

        [Required]
        public string FoilPurpose { get; set; } = null!;
    }
}
