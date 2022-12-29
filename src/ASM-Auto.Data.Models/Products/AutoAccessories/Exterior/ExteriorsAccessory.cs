using System.ComponentModel.DataAnnotations;

namespace ASM_Auto.Data.Models.Products.Exterior
{
    public class ExteriorsAccessory
    {
        [Key]
        public int ExteriorAccessoryId { get; set; }

        [Required]
        public string ExteriorAccessory { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
