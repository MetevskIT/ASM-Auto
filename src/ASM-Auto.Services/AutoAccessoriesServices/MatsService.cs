using ASM_Auto.Data.Models;
using ASM_Auto.Data.Models.Enums.Products;
using ASM_Auto.Data.Models.Products.AutoAccessories.Mats;
using ASM_Auto.Data.Repository;
using ASM_Auto.Services.Common;
using ASM_Auto.Services.ImageService;
using ASM_Auto.ViewModels;
using ASM_Auto.ViewModels.Administration.CreateProducts;
using ASM_Auto.ViewModels.AutoAccessories.Mats;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Services.AutoAccessoriesServices
{
    public class MatsService : IMatsService
    {
        private IRepository<MatsType> matsTypesRepository;
        private IRepository<Product> matsRepository;
        private IImageService imageService;
        public MatsService(IRepository<MatsType> matsTypesRepository,IRepository<Product> matsRepository, IImageService imageService)
        {
            this.matsRepository = matsRepository;
            this.matsTypesRepository = matsTypesRepository;
            this.imageService = imageService;
        }

        public async Task CreateMat(CreateMatViewModel model)
        {
            var product = new Product
            {
                ProductTypeId = 3,
                Title = model.Title,
                Quantity = model.Quantity,
                Description = model.Description,
                Price = model.Price,
                IsActive = model.IsActive,

                LineDescription = model.LineDescription,
                FreeDelivery = model.FreeDelivery,
               CarMakeId = model.CarMakeId,
               CarModelId = model.CarModelId,
               MatsTypeId = model.MatTypeId
            };

            foreach (var img in model.Images)
            {
                product.Images.Add(await imageService.UploadImage(img));

            }
            await matsRepository.AddAsync(product);
            await matsRepository.SaveChangesAsync();
        }

        public async Task<List<PartialProductModel>> GetMats(int currentPage = 1, int? CarMakeId = null, int? CarModelId = null, int? MatTypeId = null, OrderedProducts sorting = OrderedProducts.Newest,int productsPerPage = 20)
        {
            var products = new List<PartialProductModel>();

            var result = matsRepository.GetAll()
                .Include(i => i.Images)
                .Include(c=>c.CarMake)
                .Include(cm=>cm.CarModel)
                 .Where(pt => pt.ProductType.Type == "Mats")
                 .Where(p => p.IsActive == true);
            if (CarMakeId!=null)
            {
                result = result.Where(c => c.CarMakeId == CarMakeId);
            }
            if (CarModelId!=null)
            {
                result = result.Where(c => c.CarModelId == CarModelId);
            }

            if (MatTypeId!=null)
            {
                result = result.Where(mt=>mt.MatsTypeId==MatTypeId);
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

        public Task<int> MatsCount()
        {
            return matsRepository.GetAll()
            .Where(m => m.ProductType.Type == "Mats")
            .AsQueryable()
            .CountAsync();
        }

        public async Task<List<MatsType>> MatsTypes()
        {
            var types = await matsTypesRepository.GetAll().ToListAsync();

            return types;
        }
    }
}
