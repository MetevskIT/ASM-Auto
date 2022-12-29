using System.ComponentModel.DataAnnotations;

namespace ASM_Auto.Data.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }

        [Required]
        public ICollection<ProductType> Types { get; set; } = new List<ProductType>();
    }
}
