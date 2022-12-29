using ASM_Auto.Data.Models.Enums.Products;
using ASM_Auto.Data.Models.Products.AutoCosmetics.CleaningAccessories;
using ASM_Auto.ViewModels;
using ASM_Auto.ViewModels.Administration.CreateProducts;
using ASM_Auto.ViewModels.Administration.EditProducts;

namespace ASM_Auto.Services.Common
{
    public interface ICleaningAccessoryService
    {
        public Task<int> GetAccessoriesCount();

        public Task<List<CleaningAccessory>> GetCleaningTypes();

        public Task CreateAccessory(CreateCleaningAccessories model);

        public Task EditAccessory(EditCleaningAccessories model);

        public Task<List<PartialProductModel>> GetCleaningAccesories(int currentPage = 1, int? typeId = null, OrderedProducts sorting = OrderedProducts.Newest, int productsPerPage = 20);

    }
}
