using ASM_Auto.Data.Models;
using ASM_Auto.Data.Repository;
using ASM_Auto.Services.Common;
using ASM_Auto.ViewModels;
using ASM_Auto.ViewModels.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private IRepository<Product> productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<List<PartialProductModel>> GetNewestProducts(int count)
        {
            return await productRepository.GetAll()
                 .Include(i => i.Images)
                .OrderByDescending(p => p.AddDate)
                .Take(count)
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
        }

        public async Task<Product> GetProductById(Guid productId)
        {
            var product = await productRepository.GetAll()
                .Where(p => p.ProductId == productId)
                .Include(t=>t.ProductType)
                .Include(c=>c.ProductType.Category)
                .Include(c=>c.CarMake)
                .Include(c=>c.CarModel)
                .Include(i=>i.Images)
                .FirstOrDefaultAsync();
            if (product == null)
            {
                throw new ArgumentNullException("Продукта не е намерен!");
            }
            return product;
        }
    }
}
