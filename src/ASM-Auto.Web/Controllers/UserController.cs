using ASM_Auto.Services.Common;
using ASM_Auto.ViewModels.Cart;
using ASM_Auto.ViewModels.Order;
using ASM_Auto.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace ASM_Auto.Web.Controllers
{
    public class UserController : BaseController
    {
        private IUserService userService;
        private ICartService cartService;
        private IOrderService orderService;

        public UserController(IUserService userService, ICartService cartService, IOrderService orderService)
        {
            this.orderService = orderService;
            this.cartService = cartService;
            this.userService = userService;
        }

        private string? GetUserId() 
        {
           return User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? null;   
        }

        [HttpGet]
        public async Task<IActionResult> AddToLiked([FromQuery] Guid productId)
        {
            try
            {
                await userService.AddToLikedCollection(productId, GetUserId());


                return Redirect($"/Products/Details?productId={productId}");
            }
            catch (Exception ex)
            {

                return View("Error");
            }

        }

        [HttpGet]
        public async Task<IActionResult> RemoveFromLiked([FromQuery] Guid productId, bool redirect = true)
        {
            try
            {
                await userService.RemoveFromLikedCollection(productId, GetUserId());

                if (redirect)
                {
                    return Redirect($"/Products/Details?productId={productId}");

                }
                else
                {
                    return RedirectToAction("LikedProducts", "User");
                }
            }
            catch (Exception ex)
            {

                return View("Error", ex);
            }
         
        }


        [HttpGet]
        public async Task<IActionResult> AddToCart([FromQuery]Guid productId, int quantity,bool redirect=true) 
        {

            try
            {
                await cartService.AddToCart(productId, quantity, GetUserId());
                if (redirect)
                {
                    return Redirect($"/Products/Details?productId={productId}");

                }
                else 
                {
                    await userService.RemoveFromLikedCollection(productId, GetUserId());
                    return RedirectToAction("LikedProducts", "User");
                }

            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> RemoveFromCart([FromQuery] Guid productId)
        {

            try
            {
                await cartService.RemoveFromCart(productId, GetUserId());
                return RedirectToAction("Cart");

            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            try
            {
                var model = new AllCartProductsViewModel
                {
                    Products = await cartService.GetProducts(GetUserId())
                };

                return View(model);
            }
            catch (Exception ex)
            {

                return View("Error");
            }
          
        }

        [HttpGet]
        public async Task<IActionResult> Orders()
        {
            var model = new AllOrders
            {
                Orders = await orderService.GetOrders()
            };


            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> LikedProducts()
        {
            var model = new AllLikedProductsViewModel
            {
                LikedProducts = await userService.GetLikedProducts(GetUserId())
            };
            return View(model);
        }


    }
}
