using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Models
{
    public class Category
    {
        public Category()
        {
            Types = new List<ProductType>();
        }

        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; } = null!;

        [Required]
        public ICollection<ProductType> Types { get; set; }
    }
}
