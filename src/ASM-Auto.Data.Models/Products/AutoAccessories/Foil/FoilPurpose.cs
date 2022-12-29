using System.ComponentModel.DataAnnotations;

namespace ASM_Auto.Data.Models.Products.Foil
{
    public class FoilsPurpose
    {
        [Key]
        public int FoilPurposeId { get; set; }

        [Required]
        public string FoilPurpose { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
