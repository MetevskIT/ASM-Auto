using ASM_Auto.Data.Models.Products.Ledlights;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ASM_Auto.ViewModels.Administration.CreateProducts
{
    public class CreateLedLightViewModel
    {
        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string? Title { get; set; }

        [Required]
        [Range(0.00, 9999.00)]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; } = 50;

        [Required]
        [StringLength(200, MinimumLength = 5)]
        public string? Description { get; set; }

        public string? LineDescription { get; set; }

        [Required]
        public bool FreeDelivery { get; set; } = false;

        [Required]
        public bool IsActive { get; set; } = true;

        public List<IFormFile> Images { get; set; } = new List<IFormFile>();

        [Required]
        public int? LedlightsColorId { get; set; }

        [Required]
        public int? LedlightsFormatId { get; set; }

        [Required]
        public int? LedlightsPowerId { get; set; }

        [Required]
        public int? LedlightsTypeId { get; set; }

        public IEnumerable<LedlightsColor> LedlightsColors { get; set; } = new List<LedlightsColor>();

        public IEnumerable<LedlightsFormat> LedlightsFormats { get; set; } = new List<LedlightsFormat>();

        public IEnumerable<LedlightsPower> LedlightsPowers { get; set; } = new List<LedlightsPower>();

        public IEnumerable<LedlightsType> LedlightsTypes { get; set; } = new List<LedlightsType>();

    }
}
