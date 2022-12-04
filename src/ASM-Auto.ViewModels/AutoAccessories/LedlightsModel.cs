using System.ComponentModel.DataAnnotations;

namespace ASM_Auto.Web.ViewModels.AutoAccessories
{
    public class LedlightsModel
    {
        [Required]
        public string? Title { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public bool FreeDelivery { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public string? ImageUrl { get; set; }
        [Required]
        public int? ProductTypeId { get; set; }
        [Required]
        public int? LedlightsColorId { get; set; }
        [Required]
        public int? LedlightsFormatId { get; set; }
        [Required]
        public int? LedlightsPowerId { get; set; }
        [Required]
        public int? LedlightsTypeId { get; set; }

    }
}
