using System.ComponentModel.DataAnnotations;

namespace ASM_Auto.Data.Models.Products.AutoAccessories.Mats
{
    public class MatsType
    {
        [Key]
        public int MatsTypeId { get; set; }

        [Required]
        public string MatsTypeName { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
