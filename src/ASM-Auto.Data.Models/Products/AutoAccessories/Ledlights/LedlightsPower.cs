using System.ComponentModel.DataAnnotations;

namespace ASM_Auto.Data.Models.Products.Ledlights
{
    public class LedlightsPower
    {
        [Key]
        public int LedlightsPowerId { get; set; }

        [Required]
        public string LedlightPower { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
