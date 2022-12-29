using System.ComponentModel.DataAnnotations;

namespace ASM_Auto.Data.Models.Products.AutoCosmetics.CleaningAccessories
{
    public class CleaningAccessory
    {
        [Key]
        public int CleaningAccessoryId { get; set; }

        [Required]
        public string CleaningAccessoryName { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
