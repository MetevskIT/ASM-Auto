using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM_Auto.Data.Models
{
    public class ProductType 
    {
        [Key]
        public int ProductTypeId { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
