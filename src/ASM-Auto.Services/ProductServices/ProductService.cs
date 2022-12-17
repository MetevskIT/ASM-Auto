using ASM_Auto.Data.Models;
using ASM_Auto.Data.Models.Enums.Products;
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
        private IRepository<ProductType> porductTypeRepo;

        public ProductService(IRepository<Product> productRepository, IRepository<ProductType> porductTypeRepo)
        {
            this.productRepository = productRepository;
            this.porductTypeRepo = porductTypeRepo;
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

        public async Task<IEnumerable<PartialProductModel>> GetProducts(int currentPage, int? productTypeId = null, bool IsActive = true, OrderedProducts sorting = OrderedProducts.Newest, int productsPerPage = 20)
        {
            
            var result = new List<PartialProductModel>();

            var products = this.productRepository.GetAll()
                .Include(i => i.Images)
                .Where(p => p.IsActive == true)
                .AsQueryable();

            if (productTypeId != null)
            {
                products = products.Where(p => p.ProductTypeId == productTypeId);
            }

            if (!IsActive)
            {
                products = products.Where(p => p.IsActive == false);
            }

            switch (sorting)
            { 
                case OrderedProducts.PriceLowest:
                    products = products.OrderByDescending(l => l.Price);
                    break;
                case OrderedProducts.PriceHighest:
                    products = products.OrderBy(l => l.Price);
                    break;
                default:
                    products = products.OrderByDescending(l => l.AddDate);
                    break;
            }

            result = await products
                .Skip((currentPage-1)*productsPerPage)
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
            return result;
        }

        public async Task<List<ProductType>> GetProductTypes()
        {
            var result= await this.porductTypeRepo.GetAll().ToListAsync();
            return result;
        }
    }
}
