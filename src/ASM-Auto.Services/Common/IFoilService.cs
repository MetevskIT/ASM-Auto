using ASM_Auto.Data.Models.Enums.Products;
using ASM_Auto.Data.Models.Products.Foil;
using ASM_Auto.ViewModels;
using ASM_Auto.ViewModels.Administration.CreateProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Services.Common
{
    public interface IFoilService
    {
        public Task<int> GetFoilsCount();
        public Task<List<FoilsPurpose>> GetFoilsPurposes();
        public Task<List<FoilsColor>> GetFoilsColors();
        public Task<List<FoilsType>> GetTypes();
        public Task CreateFoil(CreateFoilViewModel model);
        public Task<List<PartialProductModel>> GetFoils(int currentPage = 1, int? foilTypeId = null, int? ColorId = null, int? purposeId = null, OrderedProducts sorting = OrderedProducts.Newest, int productsPerPage = 20);
    }
}
