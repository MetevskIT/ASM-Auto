using System.ComponentModel.DataAnnotations;

namespace ASM_Auto.Data.Models.Products.Ledlights
{
    public class LedlightsType
    {
        [Key]
        public int LedlightsTypeId { get; set; }

        [Required]
        public string LedlightType { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
