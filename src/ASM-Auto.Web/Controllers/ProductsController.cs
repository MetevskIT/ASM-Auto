using ASM_Auto.Services.Common;
using ASM_Auto.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ASM_Auto.Web.Controllers
{
    public class ProductsController : BaseController
    {
        private IProductService productService;
        private IUserService userService;
        public ProductsController(
            IProductService productService,
            IUserService userService)
        {
            this.userService = userService;
            this.productService = productService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(Guid productId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            try
            {
                var product = await productService.GetProductById(productId);
                var model = new DetailsViewModel()
                {
                    productId = product.ProductId,
                    Title = product.Title,
                    Images = product.Images,
                    Description = product.Description,
                    LineDescription = product.LineDescription,
                    Price = product.Price,
                    Type = product.ProductType.Type,
                    Category = product.ProductType.Category.CategoryName,
                    Make = product.CarMake?.CarMakeText ?? null,
                    Model = product.CarModel?.CarModelText ?? null,
                    IsLiked = await userService.IsLiked(productId, userId),
                    NewPrice = product.NewPrice ?? null,
                    IsAvailable = product.IsAvailable,
                    IsFreeDelivery = product.FreeDelivery

                };

                return View(model);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
    }
}
