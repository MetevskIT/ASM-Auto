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

        public async Task AddToCart([FromQuery]Guid paramId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;



        }

        [HttpGet]
        public async Task<IActionResult> AddToLiked([FromQuery] Guid paramId) 
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            await userService.AddToLikedCollection(paramId, userId);

            return View();
        }
    }
}
