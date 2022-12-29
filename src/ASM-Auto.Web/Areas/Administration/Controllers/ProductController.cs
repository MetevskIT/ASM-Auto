using ASM_Auto.Services.Common;
using ASM_Auto.ViewModels;
using ASM_Auto.ViewModels.Administration.Products;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ASM_Auto.Web.Areas.Administration.Controllers
{
    public class ProductController : BaseController
    {
        private IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> All([FromQuery] AllProductsQueryModel model)
        {
            var products = await productService.GetProducts(model.currentPage, model.ProductTypeId, model.IsActive, model.OrderedProducts);
            model.ProductTypes = await productService.GetProductTypes();
            model.Products = products;
            return View(model);
        }

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
