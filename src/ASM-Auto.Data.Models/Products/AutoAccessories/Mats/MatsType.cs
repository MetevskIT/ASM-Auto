using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Models.Products.AutoAccessories.Mats
{
    public class MatsType
    {
        [Key]
        public int MatsTypeId { get; set; }

        [Required]
        public string MatsTypeName { get; set; } = null!;

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
