using ASM_Auto.Data.Models.Enums.Products;
using ASM_Auto.Data.Models.Products.AutoCosmetics.CleaningAccessories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.ViewModels.AutoCosmetics.CleaningAccessories
{
    public class CleaningAccessoriesQueryModel
    {
        public int currentPage { get; set; } = 1;

        public const int productsPerPage = 20;
        public int AccessoriesCount { get; set; }
        public OrderedProducts OrderedProducts { get; set; }

        public int? AccessoriesTypeId { get; set; }

        public IEnumerable<CleaningAccessory> AccessoriesType { get; set; }

        public IEnumerable<PartialProductModel>? Accessories { get; set; } = new List<PartialProductModel>();
    }
}
