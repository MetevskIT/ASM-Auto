using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.ViewModels.AutoAccessories.Mats
{
    public class MatsViewModel
    {
        [Required]
        public Guid MatId { get; set; }

        [Required]
        public string? Title { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public bool FreeDelivery { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public string? ImageUrl { get; set; }
        [Required]
        public int? ProductTypeId { get; set; }

    }
}
