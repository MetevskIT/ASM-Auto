using ASM_Auto.Data.Models;
using ASM_Auto.Data.Models.Enums.Products;

namespace ASM_Auto.ViewModels.Administration.Products
{
    public class AllProductsQueryModel
    {
        public AllProductsQueryModel()
        {
            this.ProductTypes = new List<ProductType>();
            this.Products = new List<PartialProductModel>();
        }
        public int currentPage { get; set; } = 1;

        public const int productsPerPage = 20;

        public int ProductsCount { get; set; }

        public int? ProductTypeId { get; set; }

        public bool IsActive { get; set; } 

        public IEnumerable<ProductType>? ProductTypes { get; set; }

        public OrderedProducts OrderedProducts { get; set; }

        public IEnumerable<PartialProductModel>? Products { get; set; }
    }
}
