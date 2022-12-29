using ASM_Auto.Data.Models;
using ASM_Auto.Data.Repository;
using ASM_Auto.Services.Common;
using ASM_Auto.ViewModels.Cart;
using Microsoft.EntityFrameworkCore;

namespace ASM_Auto.Services.CartService
{
    public class CartService : ICartService
    {
        private IRepository<Cart> cartRepository;
        private IRepository<CartProduct> cartProductRepository;
        private IRepository<Product> productRepository;

        public CartService(
            IRepository<Cart> cartRepository,
            IRepository<CartProduct> cartProductRepository,
            IRepository<Product> productRepository)
        {
            this.cartRepository = cartRepository;
            this.cartProductRepository = cartProductRepository;
            this.productRepository = productRepository;
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

        public async Task<List<CartViewModel>> GetProducts(string userId)
        {
            var userCart = await cartRepository.GetAll()
                .Where(c => c.UserId == userId)
                .FirstOrDefaultAsync();

            if (userCart == null)
            {
                throw new ArgumentNullException("Възникна грешка!");
            }

            var products = await cartProductRepository.GetAll()
              .Include(p => p.Product)
              .ThenInclude(i => i.Images)
              .Where(c => c.CartId == userCart.CartId)
              .Select(p => new CartViewModel
              {
                  ProductId = p.ProductId,
                  Title = p.Product.Title,
                  Quantity = p.ProductCount,
                  Price = p.Product.Price,
                  ImageUrl = p.Product.Images.FirstOrDefault().ImageUrl,
              })
              .ToListAsync();

            return products;

        }

        public async Task AddToCart(Guid productId, int quantity, string userId)
        {
            var product = await productRepository.GetAll()
                .Where(x => x.ProductId == productId)
                .FirstOrDefaultAsync();

            var userCart = await cartRepository.GetAll()
                .Where(u => u.UserId == userId)
                .Include(p => p.Products)
                .FirstOrDefaultAsync();

            if (product == null)
            {
                throw new ArgumentNullException("Продукта не е намерен!");
            }

            if (product.IsAvailable == false)
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

            if (!userCart.Products.Any(p => p.ProductId == productId))
            {
                userCart.Products.Add(new CartProduct { ProductId = product.ProductId, ProductCount = quantity });
                await cartRepository.SaveChangesAsync();
            }

            else
            {
                userCart.Products.First(x => x.ProductId == productId).ProductCount += quantity;
                await cartRepository.SaveChangesAsync();
            }
        }

        public async Task RemoveFromCart(Guid productId, string userId)
        {
            var product = await productRepository.GetAll()
               .Where(x => x.ProductId == productId)
               .FirstOrDefaultAsync();

            if (product == null)
            {
                throw new ArgumentNullException("Продукта не е намерен!");
            }

            var cartProduct = await cartProductRepository.GetAll()
                .Where(p => p.ProductId == productId)
                .FirstOrDefaultAsync();

            if (cartProduct == null)
            {
                throw new ArgumentNullException("Възникна проблем!");
            }

            var userCart = await cartRepository.GetAll()
                .Where(u => u.UserId == userId)
                .FirstOrDefaultAsync();

            if (userCart == null)
            {
                throw new ArgumentNullException("Възникна проблем!");
            }

            userCart.Products.Remove(cartProduct);
            await cartRepository.SaveChangesAsync();
        }

        public async Task<List<CartProduct>> GetCartProducts(string userId)
        {
            var cartProducts = await cartProductRepository.GetAll()
                .Include(c => c.Cart)
                .Include(p => p.Product)
                .Where(c => c.Cart.UserId == userId)
                .ToListAsync();

            return cartProducts;
        }

        public async Task RemoveAllProductsFromCart(string userId)
        {
            var products = await cartProductRepository.GetAll()
                   .Include(c => c.Cart)
                   .Where(c => c.Cart.UserId == userId)
                   .ToListAsync();

            cartProductRepository.DeleteRange(products);
            await cartProductRepository.SaveChangesAsync();
        }
    }
}
