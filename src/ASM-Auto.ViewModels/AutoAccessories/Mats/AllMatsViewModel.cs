using ASM_Auto.Data.Models.Car;
using ASM_Auto.Data.Models.Enums.Products;
using ASM_Auto.Data.Models.Products.AutoAccessories.Mats;
using ASM_Auto.Data.Models.Products.Ledlights;
using ASM_Auto.ViewModels.AutoAccessories.LedLights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.ViewModels.AutoAccessories.Mats
{
    public class AllMatsViewModel
    {
        public AllMatsViewModel()
        {
            Mats = new List<PartialProductModel>();
        }
        public int currentPage { get; set; } = 1;

        public const int productsPerPage = 20;
        public int MatsCount { get; set; }

        public int? CarMakeId { get; set; }
        public int? CarModelId { get; set; }
        public int? MatsTypeId { get; set; }

        public IEnumerable<CarMake>? CarMakes { get; set; }
        public IEnumerable<CarModel>? CarModels { get; set; }
        public IEnumerable<MatsType>? MatsTypes { get; set; }
        public OrderedProducts OrderedProducts { get; set; }

        public IEnumerable<PartialProductModel>? Mats { get; set; }
    }
}
