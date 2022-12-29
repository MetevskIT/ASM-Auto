using ASM_Auto.Data.Models.Enums.Products;

namespace ASM_Auto.ViewModels.AutoCosmetics.Autoshampoo
{
    public class AllAutoshampooQuery
    {
        public int currentPage { get; set; } = 1;


        public const int productsPerPage = 20;

        public int ShampoosCount { get; set; }

        public OrderedProducts OrderedProducts { get; set; }

        public IEnumerable<PartialProductModel>? Shampoos { get; set; } = new List<PartialProductModel>();
    }
}
