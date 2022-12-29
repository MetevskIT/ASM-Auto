using ASM_Auto.Data.Models.Enums.Products;
using ASM_Auto.ViewModels;
using ASM_Auto.ViewModels.Administration.CreateProducts;
using ASM_Auto.ViewModels.Administration.EditProducts;

namespace ASM_Auto.Services.Common
{
    public interface IAutoshampooService
    {
        public Task<int> GetShampooCount();

        public Task CreateAutoshampoo(CreateAutoshampooViewModel model);

        public Task EditAutoshampoo(EditAutoshampooViewModel model);

        public Task<List<PartialProductModel>> GetShampoos(int currentPage=1, OrderedProducts sorting = OrderedProducts.Newest, int productsPerPage=20);
    }
}
