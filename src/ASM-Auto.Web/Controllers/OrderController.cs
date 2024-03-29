﻿using ASM_Auto.Services.Common;
using ASM_Auto.ViewModels.Order;
using Ganss.Xss;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ASM_Auto.Web.Controllers
{
    public class OrderController : BaseController
    {
        private IOrderService orderService;
        private ICartService cartService;
        public OrderController(
            IOrderService orderService,
            ICartService cartService)
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
                var sanitizer = new HtmlSanitizer();
                model.FirstName = sanitizer.Sanitize(model.FirstName);
                model.LastName = sanitizer.Sanitize(model.LastName);
                model.Town = sanitizer.Sanitize(model.Town);
                model.Address = sanitizer.Sanitize(model.Address);
                model.PhoneNumber = sanitizer.Sanitize(model.PhoneNumber);

                await orderService.CreateOrder(userId, model.FirstName, model.LastName, model.Town, model.Address, model.PhoneNumber, cartProducts);

                await cartService.RemoveAllProductsFromCart(userId);

                return RedirectToAction("Orders", "User");

            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Cancel(int order)
        {
            try
            {
                await orderService.CancelOrder(order);
                return RedirectToAction("Orders", "User");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }
}
