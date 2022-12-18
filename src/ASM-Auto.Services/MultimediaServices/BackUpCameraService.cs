using ASM_Auto.Data.Models;
using ASM_Auto.Data.Models.Enums.Products;
using ASM_Auto.Data.Repository;
using ASM_Auto.Services.Common;
using ASM_Auto.Services.ImageService;
using ASM_Auto.ViewModels;
using ASM_Auto.ViewModels.Administration.CreateProducts;
using ASM_Auto.ViewModels.Administration.EditProducts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Services.MultimediaServices
{
    public class BackUpCameraService : IBackUpCameraService
    {
        private IRepository<Product> repository;
        private IImageService imageService;
        public BackUpCameraService(IRepository<Product> repository, IImageService imageService)
        {
            this.repository = repository;
            this.imageService = imageService;
        }

        public async Task CreateBackUpCamera(CreateBackupCamerasViewModel model)
        {
            var product = new Product
            {
                ProductTypeId = 7,
                Title = model.Title,
                Quantity = model.Quantity,
                Description = model.Description,
                Price = model.Price,
                IsActive = model.IsActive,

                LineDescription = model.LineDescription,
                FreeDelivery = model.FreeDelivery,
                CarMakeId = model.CarMakeId,
                CarModelId = model.CarModelId,
            };

            foreach (var img in model.Images)
            {
                product.Images.Add(await imageService.UploadImage(img));

            }
            await repository.AddAsync(product);
            await repository.SaveChangesAsync();
        }

        public async Task EditBackUpCamera(EditBackUpCameraViewModel model)
        {
            var product = await repository.GetAll()
               .Where(i => i.ProductId == model.ProductId)
               .FirstOrDefaultAsync();

            product.Title = model.Title;
            product.Quantity = model.Quantity;
            product.Description = model.Description;
            product.Price = model.Price;
            product.NewPrice = model.NewPrice;
            product.IsActive = model.IsActive;
            product.LineDescription = model.LineDescription;
            product.FreeDelivery = model.FreeDelivery;
            product.CarMakeId = model.CarMakeId;
            product.CarModelId = model.CarModelId;

            if (model.Images.Any())
            {
                product.Images.Clear();
                await imageService.RemoveImages(product.ProductId);
                foreach (var img in model.Images)
                {
                    product.Images.Add(await imageService.UploadImage(img));

                }
            }
            await repository.SaveChangesAsync();
        }

        public async Task<List<PartialProductModel>> GetProducts(int currentPage = 1, int? CarMakeId = null, int? CarModelId = null, OrderedProducts sorting = OrderedProducts.Newest, int productsPerPage = 20)
        {
            var products = new List<PartialProductModel>();

            var result = repository.GetAll()
                 .Include(i => i.Images)
                .Include(c => c.CarMake)
                .Include(cm => cm.CarModel)
                 .Where(pt => pt.ProductType.Type == "BackupCameras")
                 .Where(p => p.IsActive == true);
            if (CarMakeId != null)
            {
                result = result.Where(c => c.CarMakeId == CarMakeId);
            }
            if (CarModelId != null)
            {
                result = result.Where(c => c.CarModelId == CarModelId);
            }



            switch (sorting)
            {
                case OrderedProducts.PriceLowest:
                    result.OrderByDescending(p => p.Price);
                    break;
                case OrderedProducts.PriceHighest:
                    result.OrderBy(p => p.Price);
                    break;
                default:
                    result = result.OrderByDescending(l => l.AddDate);
                    break;
            }

            products = await result
                .Skip((currentPage - 1) * productsPerPage)
                .Take(productsPerPage)
                .Select(p => new PartialProductModel
                {
                    ProductId = p.ProductId,
                    Title = p.Title,
                    Description = p.Description,
                    Price = p.Price,
                    FreeDelivery = p.FreeDelivery,
                    ImageUrl = p.Images.FirstOrDefault().ImageUrl,
                    IsActive = p.IsActive,
                    Quantity = p.Quantity,
                    ProductTypeId = p.ProductTypeId


                }).ToListAsync();

            return products;
        }

        public Task<int> ProductCount()
        {
            return repository.GetAll()
                 .Where(pt => pt.ProductType.Type == "BackupCameras")
                 .AsQueryable()
                 .CountAsync();
        }
    }
}
