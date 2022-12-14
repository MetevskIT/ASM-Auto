using ASM_Auto.Services.Common;
using ASM_Auto.ViewModels.Cart;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace ASM_Auto.Web.Controllers
{
    public class UserController : BaseController
    {
        private IUserService userService;
        private ICartService cartService;

        public UserController(IUserService userService, ICartService cartService)
        {
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
        public async Task<IActionResult> RemoveFromLiked([FromQuery] Guid productId)
        {
            try
            {
                await userService.RemoveFromLikedCollection(productId, GetUserId());

                return Redirect($"/Products/Details?productId={productId}");
            }
            catch (Exception ex)
            {

                return View("Error", ex);
            }
         
        }
        [HttpGet]
        public async Task<IActionResult> AddToCart([FromQuery]Guid productId, int quantity) 
        {

            try
            {
                await cartService.AddToCart(productId, quantity, GetUserId());
                return Redirect($"/Products/Details?productId={productId}");

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
            return View();
        }


    }
}
