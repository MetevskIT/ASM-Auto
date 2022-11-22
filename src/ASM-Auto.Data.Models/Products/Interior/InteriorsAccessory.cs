using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Models.Products.Foil
{
    public class InteriorsAccessory
    {
        [Key]
        public int InteriorAccessoryId { get; set; }

        [Required]
        public string InteriorAccessory { get; set; } = null!;
    }
}
