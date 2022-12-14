using ASM_Auto.Services.Common;
using ASM_Auto.ViewModels.Order;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ASM_Auto.Web.Controllers
{
    public class OrderController : BaseController
    {
        private IOrderService orderService;
        private ICartService cartService;
        public OrderController(IOrderService orderService, ICartService cartService)
        {
            this.orderService = orderService;
            this.cartService = cartService;
        }

        [HttpGet]
        public IActionResult CreateOrder()
        {
            var model = new CreateOrderViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Error!");
                return View(model);
            }
            try
            {

                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                if (userId == null)
                {
                    throw new ArgumentNullException("Няма логнат потребител!");
                }

                var cartProducts = await cartService.GetCartProducts(userId);

                await orderService.CreateOrder(userId, model.FirstName, model.LastName, model.Town, model.Address,model.PhoneNumber, cartProducts);
               
                await cartService.RemoveAllProductsFromCart(userId);

                return RedirectToAction("Index", "Home");

            }
            catch (Exception ex)
            {

                return View("Error");
            }

        }
    }
}
