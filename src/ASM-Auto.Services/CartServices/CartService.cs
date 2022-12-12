using ASM_Auto.Data.Models;
using ASM_Auto.Data.Repository;
using ASM_Auto.Services.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Services.CartService
{
    public class CartService : ICartService
    {
        private IRepository<Cart> cartRepository;

        public CartService(IRepository<Cart> cartRepository)
        {
            this.cartRepository = cartRepository;
        }


        public async Task<Guid> CreateCart(string userId)
        {
            var cart = new Cart()
            {
                UserId = userId
            };
           await cartRepository.AddAsync(cart);
           await cartRepository.SaveChangesAsync();

            return cart.CartId;
        }

        //public async Task<Product> GetCartProducts(string userId)
        //{
        //    var products = await cartRepository.GetAll()
        //        .Where(c => c.UserId == userId)
        //        .Include(u => u.Products)
        //        .ThenInclude(p=>p.Product)
        //        .Select(p=> new 
        //        {

        //        })
        //        .ToListAsync();

        //    return products;
        //}
    }
}
