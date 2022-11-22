using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Models.Products.Exterior
{
    public class ExteriorsAccessory
    {
        [Key]
        public int ExteriorAccessoryId { get; set; }

        [Required]
        public string ExteriorAccessory { get; set; } = null!;
    }
}
