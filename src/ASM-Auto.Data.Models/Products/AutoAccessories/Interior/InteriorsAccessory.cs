using System.ComponentModel.DataAnnotations;

namespace ASM_Auto.Data.Models.Products.Interior
{
    public class InteriorsAccessory
    {
        [Key]
        public int InteriorAccessoryId { get; set; }

        [Required]
        public string InteriorAccessory { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
