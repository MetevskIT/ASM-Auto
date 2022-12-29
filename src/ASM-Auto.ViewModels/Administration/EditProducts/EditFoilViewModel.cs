using ASM_Auto.Data.Models.Products.Foil;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ASM_Auto.ViewModels.Administration.EditProducts
{
    public class EditFoilViewModel
    {
        [Key]
        public Guid ProductId { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string? Title { get; set; }

        [Required]
        [Range(0.00, 9999.00)]
        public decimal Price { get; set; }

        [Range(0.00, 9999.00)]
        public decimal NewPrice { get; set; }

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

        public List<IFormFile>? Images { get; set; } = new List<IFormFile>();

        [Required]
        public int? FoilType { get; set; }

        [Required]
        public int? FoilPurposeId { get; set; }

        [Required]
        public int? FoilColorId { get; set; }

        public IEnumerable<FoilsColor> FoilsColors { get; set; } = new List<FoilsColor>();

        public IEnumerable<FoilsType> FoilsTypes { get; set; } = new List<FoilsType>();

        public IEnumerable<FoilsPurpose> FoilsPurposes { get; set; } = new List<FoilsPurpose>();

    }
}
