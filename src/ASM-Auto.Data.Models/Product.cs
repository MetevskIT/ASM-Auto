using ASM_Auto.Data.Models.Car;
using ASM_Auto.Data.Models.Products.AutoAccessories.Mats;
using ASM_Auto.Data.Models.Products.AutoCosmetics.CleaningAccessories;
using ASM_Auto.Data.Models.Products.Exterior;
using ASM_Auto.Data.Models.Products.Foil;
using ASM_Auto.Data.Models.Products.Interior;
using ASM_Auto.Data.Models.Products.Ledlights;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM_Auto.Data.Models
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; } = Guid.NewGuid();

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public decimal? NewPrice { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public bool IsAvailable { get; set; } = true;

        public string? LineDescription { get; set; }

        [Required]
        public DateTime? AddDate { get; set; } = DateTime.UtcNow;

        [Required]
        [ForeignKey(nameof(ProductType))]
        public int? ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }

        [Required]
        public bool FreeDelivery { get; set; }

        [ForeignKey(nameof(CarMake))]
        public int? CarMakeId { get; set; }
        public CarMake? CarMake { get; set; }


        [ForeignKey(nameof(CarModel))]
        public int? CarModelId { get; set; }
        public CarModel? CarModel { get; set; }

        //AutoAccessories Category Products
        //Ledlight Product
        [ForeignKey(nameof(LedlightsType))]
        public int? LedlightsTypeId { get; set; }
        public LedlightsType? LedlightsType { get; set; }

        [ForeignKey(nameof(LedlightsPower))]
        public int? LedlightsPowerId { get; set; }
        public LedlightsPower? LedlightsPower { get; set; }

        [ForeignKey(nameof(LedlightsColor))]
        public int? LedlightsColorId { get; set; }
        public LedlightsColor? LedlightsColor { get; set; }

        [ForeignKey(nameof(LedlightsFormat))]
        public int? LedlightsFormatId { get; set; }
        public LedlightsFormat? LedlightsFormat { get; set; }

        //Mats Product
        [ForeignKey(nameof(MatsType))]
        public int? MatsTypeId { get; set; }
        public MatsType? MatsType { get; set; }

        //Foil Product
        [ForeignKey(nameof(FoilsType))]
        public int? FoilsTypeId { get; set; }
        public FoilsType? FoilsType { get; set; }

        [ForeignKey(nameof(FoilsColor))]
        public int? FoilsColorId { get; set; }
        public FoilsColor? FoilsColor { get; set; }

        [ForeignKey(nameof(FoilsPurpose))]
        public int? FoilsPurposeId { get; set; }
        public FoilsPurpose? FoilsPurpose { get; set; }

        //Interior Product
        [ForeignKey(nameof(InteriorsAccessory))]
        public int? InteriorsAccessoryId { get; set; }
        public InteriorsAccessory? InteriorsAccessory { get; set; }

        //Exterior Product
        [ForeignKey(nameof(ExteriorsAccessory))]
        public int? ExteriorsAccessoryId { get; set; }
        public ExteriorsAccessory? ExteriorsAccessory { get; set; }

        //AutoCosmetics Category Product
        //CleaningAccessory
        [ForeignKey(nameof(CleaningAccessory))]
        public int? CleaningAccessoryId { get; set; }
        public CleaningAccessory? CleaningAccessory { get; set; }

        public ICollection<Image> Images { get; set; } = new List<Image>();

        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public virtual ICollection<User> Liked { get; set; } = new List<User>();

        public virtual ICollection<CartProduct> Cart { get; set; } = new List<CartProduct>();


    }
}
