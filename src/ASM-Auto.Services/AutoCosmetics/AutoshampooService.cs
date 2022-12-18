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

namespace ASM_Auto.Services.AutoCosmetics
{
    public class AutoshampooService : IAutoshampooService
    {
        private IRepository<Product> repository;
        private IImageService imageService;

        public AutoshampooService(IRepository<Product> repository, IImageService imageService)
        {
            this.repository = repository;
            this.imageService = imageService;
        }

        public async Task CreateAutoshampoo(CreateAutoshampooViewModel model)
        {
            var product = new Product
            {
                ProductTypeId = 4,
                Title = model.Title,
                Quantity = model.Quantity,
                Description = model.Description,
                Price = model.Price,
                IsActive = model.IsActive,
                LineDescription = model.LineDescription,
                FreeDelivery = model.FreeDelivery,

            };

            foreach (var img in model.Images)
            {
                product.Images.Add(await imageService.UploadImage(img));

            }
            await repository.AddAsync(product);
            await repository.SaveChangesAsync();
        }

        public async Task EditAutoshampoo(EditAutoshampooViewModel model)
        {
            var product = await repository.GetAll()
                .Where(i => i.ProductId == model.productId)
                .FirstOrDefaultAsync();

            product.Title = model.Title;
            product.Quantity = model.Quantity;
            product.Description = model.Description;
            product.Price = model.Price;
            product.NewPrice = model.NewPrice;
            product.IsActive = model.IsActive;
            product.LineDescription = model.LineDescription;
            product.FreeDelivery = model.FreeDelivery;

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

        public Task<int> GetShampooCount()
        {
            return repository.GetAll()
                .Include(c=>c.ProductType)
                .Where(s => s.ProductType.Type == "Autoshampoo")
                .AsQueryable()
                .CountAsync();
        }

        public async Task<List<PartialProductModel>> GetShampoos(int currentPage = 1, OrderedProducts sorting = OrderedProducts.Newest, int productsPerPage = 20)
        {
            var products = new List<PartialProductModel>();

            var query = repository.GetAll()
                 .Include(i => i.Images)
                 .Include(c => c.ProductType)
                .Where(s => s.ProductType.Type == "Autoshampoo")
                .Where(p => p.IsActive == true);

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
    }
}
