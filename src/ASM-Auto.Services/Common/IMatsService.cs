using ASM_Auto.Data.Models.Enums.Products;
using ASM_Auto.Data.Models.Products.AutoAccessories.Mats;
using ASM_Auto.ViewModels;
using ASM_Auto.ViewModels.Administration.CreateProducts;
using ASM_Auto.ViewModels.Administration.EditProducts;
using ASM_Auto.ViewModels.AutoAccessories.Mats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Services.Common
{
    public interface IMatsService
    {
        public Task<int> MatsCount();
        public Task<List<MatsType>> MatsTypes();
        public Task CreateMat(CreateMatViewModel model);
        public Task EditMat(EditMatViewModel model);

        public Task<List<PartialProductModel>> GetMats(int currentPage=1,int? CarMakeId=null, int? CarModelId=null, int? MatTypeId=null, OrderedProducts sorting = OrderedProducts.Newest, int productsPerPage = 20); 
    }
}
