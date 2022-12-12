using ASM_Auto.Services.Common;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace ASM_Auto.Web.Controllers
{
    public class UserController : BaseController
    {
        private IUserService userService;

        public UserController(IUserService userService)
        {
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

            await userService.RemoveFromLikedCollection(productId, GetUserId());

            return Redirect($"/Products/Details?productId={productId}");
        }
        [HttpGet]
        public async Task<IActionResult> AddToCart([FromQuery] Guid productId, int quantity) 
        {

            try
            {
                await userService.AddToCart(productId, quantity, GetUserId());
                return Redirect($"/Products/Details?productId={productId}");

            }
            catch (Exception)
            {

                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            return View();
        }


    }
}
