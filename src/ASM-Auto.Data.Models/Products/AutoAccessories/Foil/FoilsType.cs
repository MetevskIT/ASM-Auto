using System.ComponentModel.DataAnnotations;

namespace ASM_Auto.Data.Models.Products.Foil
{
    public class FoilsType
    {
        [Key]
        public int FoilTypeId { get; set; }

        [Required]
        public string FoilType { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
