using ASM_Auto.Data.Models.Enums.Products;
using ASM_Auto.Data.Models.Products.Ledlights;

namespace ASM_Auto.ViewModels.AutoAccessories.LedLights
{
    public class AllLedlightsQueryModel
    {
        public AllLedlightsQueryModel()
        {
            Ledlights = Enumerable.Empty<PartialProductModel>();
        }
        public int currentPage { get; set; } = 1;

        public const int productsPerPage = 20;

        public int LedlightsCount { get; set; }

        public string? LedlightsType { get; set; }
        public string? LedlightsColor { get; set; }
        public string? LedlightsPower { get; set; }
        public string? LedlightsFormat { get; set; }

        public IEnumerable<LedlightsType>? LedlightsTypes { get; set; }
        public IEnumerable<LedlightsColor>? LedlightsColors { get; set; }
        public IEnumerable<LedlightsPower>? LedlightsPowers { get; set; }
        public IEnumerable<LedlightsFormat>? LedlightsFormats { get; set; }
        public OrderedProducts OrderedProducts { get; set; }
        public IEnumerable<PartialProductModel>? Ledlights { get; set; }
    }
}
