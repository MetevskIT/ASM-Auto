using ASM_Auto.Data.Models;
using ASM_Auto.Data.Models.Enums.Products;
using ASM_Auto.ViewModels;
using ASM_Auto.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Services.Common
{
    public interface IProductService
    {
        public Task<Product> GetProductById(Guid productId);
        public Task<List<PartialProductModel>> GetNewestProducts(int count);
        public Task<List<ProductType>> GetProductTypes();
        public Task<IEnumerable<PartialProductModel>> GetProducts(
          int currentPage,
          int? productTypeId = null,
          bool IsActive =true,
          OrderedProducts sorting = OrderedProducts.Newest,
          int productsPerPage = 20);

    }
}
