using ASM_Auto.Data.Models;
using ASM_Auto.Data.Models.Enums.Products;
using ASM_Auto.ViewModels;
using ASM_Auto.ViewModels.Administration.CreateProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Services.Common
{
    public interface IAutoshampooService
    {
        public Task<int> GetShampooCount();

        public Task CreateAutoshampoo(CreateAutoshampooViewModel model);
        public Task<List<PartialProductModel>> GetShampoos(int currentPage=1, OrderedProducts sorting = OrderedProducts.Newest, int productsPerPage=20);
    }
}
