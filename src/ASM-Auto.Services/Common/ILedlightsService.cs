﻿using ASM_Auto.Data.Models.Enums.Products;
using ASM_Auto.Data.Models.Products.Ledlights;
using ASM_Auto.ViewModels;
using ASM_Auto.ViewModels.Administration.CreateProducts;
using ASM_Auto.ViewModels.Administration.EditProducts;
using ASM_Auto.ViewModels.AutoAccessories.LedLights;

namespace ASM_Auto.Services.Common
{
    public interface ILedlightsService
    {
        public Task CreateLedLight(CreateLedLightViewModel model);

        public Task<int> GetLedlightsCount();

        public Task EditLedLight(EditLedLightViewModel model);

        public Task<IEnumerable<LedlightsColor>> GetLedlightsColors();

        public Task<IEnumerable<LedlightsFormat>> GetLedlightsFormats();

        public Task<IEnumerable<LedlightsModel>> GetLedlightsModels();

        public Task<IEnumerable<LedlightsPower>> GetLedlightsPower();

        public Task<IEnumerable<LedlightsType>> GetLedlightsTypes();

        public Task<IEnumerable<PartialProductModel>> GetLedlights(
            int currentPage,
            string? ledlightsType = null,
            string? ledlightsColor = null,
            string? ledlightsPower = null,
            string? ledlightsFormat = null,
            OrderedProducts sorting = OrderedProducts.Newest,
            int productsPerPage = 20); 

    }
}
