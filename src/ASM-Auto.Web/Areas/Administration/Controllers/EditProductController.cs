using ASM_Auto.Data.Models;
using ASM_Auto.Data.Models.Car;
using ASM_Auto.Services.Common;
using ASM_Auto.Services.ImageService;
using ASM_Auto.Services.ProductServices;
using ASM_Auto.Services.UserServices;
using ASM_Auto.ViewModels;
using ASM_Auto.ViewModels.Administration.EditProducts;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace ASM_Auto.Web.Areas.Administration.Controllers
{
    public class EditProductController : BaseController
    {
        private IProductService productService;
        private IMatsService matsService;
        private ICarService carService;
        private IImageService imageService;
        public EditProductController(IProductService productService, IMatsService matsService,ICarService carService, IImageService imageService)
        {
            this.productService = productService;
            this.matsService = matsService;
            this.carService = carService;
            this.imageService = imageService;
        }

        [HttpGet]
        public async Task<IActionResult> Mats(Guid productId)
        {
            try
            {
                var product = await productService.GetProductById(productId);
                var model = new EditMatViewModel
                {
                    ProductId = product.ProductId,
                    Title = product.Title,
                    Quantity = product.Quantity,
                    Description = product.Description,
                    Price = product.Price,
                    IsActive = product.IsActive,
                    LineDescription = product.LineDescription,
                    FreeDelivery = product.FreeDelivery,
                    CarMakeId = product.CarMakeId,
                    CarModelId = product.CarModelId,
                    MatTypeId = product.MatsTypeId
                };
                model.CarMakes = await carService.CarMakes();
                model.MatsTypes = await matsService.MatsTypes();


                return View(model);
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Mats(EditMatViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                await matsService.EditMat(model);
                return Redirect($"/Product/Details?productId={model.ProductId}");
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }
    }
}
