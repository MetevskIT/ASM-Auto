using System.ComponentModel.DataAnnotations;

namespace ASM_Auto.Data.Models.Products.Foil
{
    public class FoilsColor
    {
        [Key]
        public int FoilColorId { get; set; }

        [Required]
        public string FoilColor { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
