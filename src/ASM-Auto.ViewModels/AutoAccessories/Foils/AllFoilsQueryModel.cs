using ASM_Auto.Data.Models.Enums.Products;
using ASM_Auto.Data.Models.Products.Foil;

namespace ASM_Auto.ViewModels.AutoAccessories.Foils
{
    public class AllFoilsQueryModel
    {
        public int currentPage { get; set; } = 1;

        public const int productsPerPage = 20;
        public int FoilsCount { get; set; }

        public int? FoilsPurposeId { get; set; }
        public int? FoilsColorId { get; set; }
        public int? FoilsTypeId { get; set; }

        public IEnumerable<FoilsPurpose>? FoilsPurposes { get; set; }
        public IEnumerable<FoilsColor>? FoilsColors { get; set; }
        public IEnumerable<FoilsType>? FoilsTypes { get; set; }
        public OrderedProducts OrderedProducts { get; set; }

        public IEnumerable<PartialProductModel>? Foils { get; set; } = new List<PartialProductModel>();
    }
}
