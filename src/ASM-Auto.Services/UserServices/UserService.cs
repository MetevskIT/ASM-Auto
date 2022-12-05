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

        public async Task AddToLikedCollection(Guid productId, string userId)
        {
            var product = await productRepository.GetAll()
                 .Where(x => x.ProductId == productId)
                 .FirstOrDefaultAsync();

            var user = await userRepository.GetAll()
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();

            if (product==null)
            {
                throw new ArgumentNullException("Продукта не е намерен!");
            }

            if (user==null)
            {
                throw new ArgumentNullException("Потребителя не е намерен!");
            }

            user.LikedProducts.Add(product);
            await userRepository.SaveChangesAsync();
            await productRepository.SaveChangesAsync();
        }

        public async Task RemoveFromLikedCollection(Guid productId, string userId)
        {
            var product = await productRepository.GetAll()
               .Where(x => x.ProductId == productId)
               .FirstOrDefaultAsync();

            var user = await userRepository.GetAll()
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();

            if (product == null)
            {
                throw new ArgumentNullException("Продукта не е намерен!");
            }

            if (user == null)
            {
                throw new ArgumentNullException("Потребителя не е намерен!");
            }

            if (user.LikedProducts.Contains(product))
            {
                user.LikedProducts.Remove(product);
                await userRepository.SaveChangesAsync();
                await productRepository.SaveChangesAsync();
            }
        }
    }
}
