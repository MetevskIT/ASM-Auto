using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Models.Products.AutoCosmetics.CleaningAccessories
{
    public class CleaningAccessory
    {
        [Key]
        public int CleaningAccessoryId { get; set; }

        [Required]
        public string CleaningAccessoryName { get; set; } = null!;

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
