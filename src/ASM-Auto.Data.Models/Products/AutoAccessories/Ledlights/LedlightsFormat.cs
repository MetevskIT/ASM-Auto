using System.ComponentModel.DataAnnotations;

namespace ASM_Auto.Data.Models.Products.Ledlights
{
    public class LedlightsFormat
    {
        [Key]
        public int LedlightsFormatId { get; set; }

        [Required]
        public string LedlightFormat { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
