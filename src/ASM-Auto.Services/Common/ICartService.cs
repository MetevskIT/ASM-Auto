using ASM_Auto.Data.Models;
using ASM_Auto.ViewModels.Cart;

namespace ASM_Auto.Services.Common
{
    public interface ICartService
    {
        public Task<Guid> CreateCart(string userId);

        public Task<List<CartViewModel>> GetProducts(string userId);

        public Task<List<CartProduct>> GetCartProducts(string userId);

        public Task RemoveFromCart(Guid productId, string userId);

        public Task AddToCart(Guid productId, int quantity, string userId);

        public Task RemoveAllProductsFromCart(string userId);
    }
}
