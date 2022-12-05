using ASM_Auto.Data.Models;
using ASM_Auto.Data.Repository;
using ASM_Auto.Services.Common;
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

        public async Task CreateCart(string userId)
        {
            var cart = new Cart()
            {
                UserId = userId
            };
           await cartRepository.AddAsync(cart);
           await cartRepository.SaveChangesAsync();
        }
    }
}
