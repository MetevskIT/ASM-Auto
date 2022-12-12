using ASM_Auto.Data.Models;
using ASM_Auto.Data.Repository;
using ASM_Auto.Services.Common;
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

        public async Task<Product> GetProductById(Guid productId)
        {
            var product = await productRepository.GetAll()
                .Where(p => p.ProductId == productId)
                .Include(t=>t.ProductType)
                .Include(c=>c.ProductType.Category)
                .FirstOrDefaultAsync();
            if (product == null)
            {
                throw new ArgumentNullException("Продукта не е намерен!");
            }
            return product;
        }
    }
}
