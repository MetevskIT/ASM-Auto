using ASM_Auto.Data.Models;
using ASM_Auto.Data.Models.Enums.Products;
using ASM_Auto.Data.Models.Products.AutoCosmetics.CleaningAccessories;
using ASM_Auto.Data.Repository;
using ASM_Auto.Services.Common;
using ASM_Auto.Services.ImageService;
using ASM_Auto.ViewModels;
using ASM_Auto.ViewModels.Administration.CreateProducts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Services.AutoCosmetics
{
    public class CleaningAccessoryService : ICleaningAccessoryService
    {
        private IRepository<Product> repository;
        private IRepository<CleaningAccessory> accesoriesRepository;
        private IImageService imageService;

        public CleaningAccessoryService(IRepository<Product> repository, IRepository<CleaningAccessory> accesoriesRepository, IImageService imageService)
        {
            this.repository = repository;
            this.accesoriesRepository = accesoriesRepository;
            this.imageService = imageService;
        }

        public async Task CreateAccessory(CreateCleaningAccessories model)
        {
            var product = new Product
            {
                ProductTypeId = 5,
                Title = model.Title,
                Quantity = model.Quantity,
                Description = model.Description,
                Price = model.Price,
                IsActive = model.IsActive,

                LineDescription = model.LineDescription,
                FreeDelivery = model.FreeDelivery,
                CleaningAccessoryId = model.CleaningAccessoryId
            };

            foreach (var img in model.Images)
            {
                product.Images.Add(await imageService.UploadImage(img));

            }
            await repository.AddAsync(product);
            await repository.SaveChangesAsync();
        }

        public Task<int> GetAccessoriesCount()
        {
            return this.repository.GetAll()
                .Include(t => t.ProductType)
                .Where(t => t.ProductType.Type == "CleaningTools")
                .AsQueryable()
                .CountAsync();
        }

        public async Task<List<PartialProductModel>> GetCleaningAccesories(int currentPage = 1, int? typeId = null, OrderedProducts sorting = OrderedProducts.Newest, int productsPerPage = 20)
        {
            var products = new List<PartialProductModel>();

            var query = repository.GetAll()
                 .Include(i => i.Images)
                 .Include(c => c.ProductType)
                 .Include(c=>c.CleaningAccessory)
                .Where(s => s.ProductType.Type == "CleaningTools")
                .Where(p => p.IsActive == true);

            if (typeId!=null)
            {
                query.Where(t => t.CleaningAccessoryId == typeId);
            }
            switch (sorting)
            {
                case OrderedProducts.PriceLowest:
                    query = query.OrderByDescending(l => l.Price);
                    break;
                case OrderedProducts.PriceHighest:
                    query = query.OrderBy(l => l.Price);
                    break;
                default:
                    query = query.OrderByDescending(l => l.AddDate);
                    break;
            }
            products = await query
                .Skip((currentPage - 1) * productsPerPage)
                .Take(productsPerPage)
                .Select(p => new PartialProductModel
                {
                    Title = p.Title,
                    Description = p.Description,
                    FreeDelivery = p.FreeDelivery,
                    ImageUrl = p.Images.FirstOrDefault().ImageUrl,
                    Price = p.Price,
                    IsActive = p.IsActive,
                    ProductId = p.ProductId,
                    ProductTypeId = p.ProductTypeId,
                    Quantity = p.Quantity
                })
                .ToListAsync();

            return products;
        }

        public async Task<List<CleaningAccessory>> GetCleaningTypes()
        {
            return await this.accesoriesRepository.GetAll().ToListAsync();
        }
    }
}
