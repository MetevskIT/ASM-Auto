using ASM_Auto.Data.Models;
using ASM_Auto.Data.Repository;
using ASM_Auto.Services.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Services.UserServices
{
    public class UserService : IUserService
    {
        private IRepository<User> userRepository;
        private IRepository<Product> productRepository;

        public UserService(IRepository<User> userRepository, IRepository<Product> productRepository)
        {
            this.userRepository = userRepository;
            this.productRepository = productRepository;
        }

        public async Task AddToCart(Guid productId, int quantity, string userId)
        {
            var product = await productRepository.GetAll()
                .Where(x => x.ProductId == productId)
                .FirstOrDefaultAsync();

            var userCart = await userRepository.GetAll()
                .Where(u => u.Id == userId)
                .Include(c=>c.Cart)
                .ThenInclude(p=>p.Products)
                .Select(c=>c.Cart)
                .FirstOrDefaultAsync();

            if (product == null)
            {
                throw new ArgumentNullException("Продукта не е намерен!");
            }

            if (product.IsAvailable==false)
            {
                throw new Exception("Продукта не е наличен!");
            }
            if (product.IsActive == false)
            {
                throw new Exception("Продукта е неактивен!");
            }

            if (userCart == null)
            {
                throw new ArgumentNullException("Възникна проблем!");
            }
            if (!userCart.Products.Any(p=>p.ProductId==productId))
            {
                userCart.Products.Add(new CartProduct { ProductId = product.ProductId, ProductCount = quantity });
                await userRepository.SaveChangesAsync();
            }
            else
            {
                userCart.Products.First(x=>x.ProductId==productId).ProductCount+=quantity;
                await userRepository.SaveChangesAsync();
            }

        }

        public async Task AddToLikedCollection(Guid productId, string userId)
        {
            var product = await productRepository.GetAll()
                 .Where(x => x.ProductId == productId)
                 .FirstOrDefaultAsync();

            var user = await userRepository.GetAll()
                .Where(u => u.Id == userId)
                .Include(u=>u.LikedProducts)
                .FirstOrDefaultAsync();

            if (product==null)
            {
                throw new ArgumentNullException("Продукта не е намерен!");
            }

            if (user==null)
            {
                throw new ArgumentNullException("Потребителя не е намерен!");
            }
            if (!user.LikedProducts.Any(x => x.ProductId ==productId))
            {
                user.LikedProducts.Add(product);
                await userRepository.SaveChangesAsync();
                await productRepository.SaveChangesAsync();
            }
        }

        public async Task<bool> IsLiked(Guid productId, string? userId)
        {
            var user = await userRepository.GetAll()
                .Where(u => u.Id == userId)
                .Include(u => u.LikedProducts)
                .FirstOrDefaultAsync();
            if (user==null)
            {
                return false;
            }
            var product = await productRepository.GetAll()
               .Where(x => x.ProductId == productId)
               .FirstOrDefaultAsync();
            if (product == null)
            {
                throw new ArgumentNullException("Продукта не е намерен!");
            }

            return user.LikedProducts.Any(x => x.ProductId == productId) ? true : false;
        }

        public async Task RemoveFromLikedCollection(Guid productId, string userId)
        {
            var product = await productRepository.GetAll()
               .Where(x => x.ProductId == productId)
               .FirstOrDefaultAsync();

            var user = await userRepository.GetAll()
                .Where(u => u.Id == userId)
                .Include(u => u.LikedProducts)
                .FirstOrDefaultAsync();

            if (product == null)
            {
                throw new ArgumentNullException("Продукта не е намерен!");
            }

            if (user == null)
            {
                throw new ArgumentNullException("Потребителя не е намерен!");
            }

            if (user.LikedProducts.Any(x => x.ProductId == productId))
            {
                user.LikedProducts.Remove(product);
                await userRepository.SaveChangesAsync();
                await productRepository.SaveChangesAsync();
            }
        }
    }
}
