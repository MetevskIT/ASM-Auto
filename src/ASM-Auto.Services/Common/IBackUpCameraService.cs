﻿using ASM_Auto.Data.Models.Enums.Products;
using ASM_Auto.ViewModels;
using ASM_Auto.ViewModels.Administration.CreateProducts;
using ASM_Auto.ViewModels.Administration.EditProducts;

namespace ASM_Auto.Services.Common
{
    public interface IBackUpCameraService
    {
        public Task<int> ProductCount();

        public Task CreateBackUpCamera(CreateBackupCamerasViewModel model);

        public Task EditBackUpCamera(EditBackUpCameraViewModel model);

        public Task<List<PartialProductModel>> GetProducts(int currentPage = 1, int? CarMakeId = null, int? CarModelId = null, OrderedProducts sorting = OrderedProducts.Newest, int productsPerPage = 20);
    }
}
