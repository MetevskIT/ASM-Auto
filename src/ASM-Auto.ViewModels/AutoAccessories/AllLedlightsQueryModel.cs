
using ASM_Auto.Data.Models.Enums.Products;
using ASM_Auto.Data.Models.Products.Ledlights;
using ASM_Auto.Web.ViewModels.AutoAccessories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Web.ViewModels.AutoAccessories
{
    public class AllLedlightsQueryModel
    {
        public AllLedlightsQueryModel()
        {
            this.Ledlights = Enumerable.Empty<LedlightsModel>();
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

        public IEnumerable<LedlightsModel>? Ledlights { get; set; } 
    }
}
