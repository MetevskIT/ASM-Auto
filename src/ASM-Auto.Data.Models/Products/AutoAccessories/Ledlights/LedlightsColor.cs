using System.ComponentModel.DataAnnotations;

namespace ASM_Auto.Data.Models.Products.Ledlights
{
    public class LedlightsColor
    {
        [Key]
        public int LedlightsColorId { get; set; }

        [Required]
        public string LedlightColor { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
