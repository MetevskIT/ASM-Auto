using ASM_Auto.Services.Common;
using ASM_Auto.ViewModels.Administration.EditProducts;
using Microsoft.AspNetCore.Mvc;

namespace ASM_Auto.Web.Areas.Administration.Controllers
{
    public class EditProductController : BaseController
    {
        private IProductService productService;
        private IMatsService matsService;
        private ICarService carService;
        private IImageService imageService;
        private IFoilService foilService;
        private ILedlightsService ledlightsService;
        private IAutoshampooService autoshampooService;
        private ICleaningAccessoryService cleaningAccessoryService;
        private IMultimediaService multimediaService;
        private IBackUpCameraService backUpCameraService;

        public EditProductController(
            IProductService productService,
            IMatsService matsService,
            ICarService carService,
            IImageService imageService,
            IFoilService foilService,
            ILedlightsService ledlightsService,
            IAutoshampooService autoshampooService,
            ICleaningAccessoryService cleaningAccessoryService,
            IMultimediaService multimediaService,
            IBackUpCameraService backUpCameraService)
        {
            this.productService = productService;
            this.matsService = matsService;
            this.carService = carService;
            this.imageService = imageService;
            this.foilService = foilService;
            this.ledlightsService = ledlightsService;
            this.autoshampooService = autoshampooService;
            this.cleaningAccessoryService = cleaningAccessoryService;
            this.multimediaService = multimediaService;
            this.backUpCameraService = backUpCameraService;
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

        [HttpGet]
        public async Task<IActionResult> Foil(Guid productId)
        {
            try
            {
                var product = await productService.GetProductById(productId);
                var model = new EditFoilViewModel
                {
                    ProductId = product.ProductId,
                    Title = product.Title,
                    Quantity = product.Quantity,
                    Description = product.Description,
                    Price = product.Price,
                    IsActive = product.IsActive,
                    LineDescription = product.LineDescription,
                    FreeDelivery = product.FreeDelivery,
                    FoilColorId = product.FoilsColorId,
                    FoilType = product.FoilsColorId,
                    FoilPurposeId = product.FoilsColorId
                };
                model.FoilsTypes = await foilService.GetTypes();
                model.FoilsColors = await foilService.GetFoilsColors();
                model.FoilsPurposes = await foilService.GetFoilsPurposes();

                return View(model);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Foil(EditFoilViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                await foilService.EditFoil(model);
                return Redirect($"/Product/Details?productId={model.ProductId}");
            }

            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> LedLights(Guid productId)
        {
            try
            {
                var product = await productService.GetProductById(productId);
                var model = new EditLedLightViewModel
                {
                    ProductId = product.ProductId,
                    Title = product.Title,
                    Quantity = product.Quantity,
                    Description = product.Description,
                    Price = product.Price,
                    IsActive = product.IsActive,
                    LineDescription = product.LineDescription,
                    FreeDelivery = product.FreeDelivery,
                    LedlightsColorId = product.LedlightsColorId,
                    LedlightsFormatId = product.LedlightsFormatId,
                    LedlightsPowerId = product.LedlightsPowerId,
                    LedlightsTypeId = product.LedlightsTypeId

                };
                model.LedlightsTypes = await ledlightsService.GetLedlightsTypes();
                model.LedlightsFormats = await ledlightsService.GetLedlightsFormats();
                model.LedlightsPowers = await ledlightsService.GetLedlightsPower();
                model.LedlightsColors = await ledlightsService.GetLedlightsColors();

                return View(model);
            }

            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> LedLights(EditLedLightViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                await ledlightsService.EditLedLight(model);
                return Redirect($"/Product/Details?productId={model.ProductId}");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Autoshampoo(Guid productId)
        {
            try
            {
                var product = await productService.GetProductById(productId);
                var model = new EditAutoshampooViewModel
                {
                    productId = product.ProductId,
                    Title = product.Title,
                    Quantity = product.Quantity,
                    Description = product.Description,
                    Price = product.Price,
                    IsActive = product.IsActive,
                    LineDescription = product.LineDescription,
                    FreeDelivery = product.FreeDelivery
                };
                return View(model);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Autoshampoo(EditAutoshampooViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                await autoshampooService.EditAutoshampoo(model);
                return Redirect($"/Product/Details?productId={model.productId}");
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> CleaningTools(Guid productId)
        {
            try
            {
                var product = await productService.GetProductById(productId);
                var model = new EditCleaningAccessories
                {
                    ProductId = product.ProductId,
                    Title = product.Title,
                    Quantity = product.Quantity,
                    Description = product.Description,
                    Price = product.Price,
                    IsActive = product.IsActive,
                    LineDescription = product.LineDescription,
                    FreeDelivery = product.FreeDelivery,
                    CleaningAccessoryId = product.CleaningAccessoryId
                };
                model.cleaningAccessories = await cleaningAccessoryService.GetCleaningTypes();
                return View(model);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CleaningTools(EditCleaningAccessories model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                await cleaningAccessoryService.EditAccessory(model);
                return Redirect($"/Product/Details?productId={model.ProductId}");
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Multimedia(Guid productId)
        {
            try
            {
                var product = await productService.GetProductById(productId);
                var model = new EditNavigationViewModel
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
                    CarModelId = product.CarModelId
                };
                model.CarMakes = await carService.CarMakes();
                return View(model);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Multimedia(EditNavigationViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                await multimediaService.EditMultimedia(model);
                return Redirect($"/Product/Details?productId={model.ProductId}");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> BackUpCameras(Guid productId)
        {
            try
            {
                var product = await productService.GetProductById(productId);
                var model = new EditBackUpCameraViewModel
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
                    CarModelId = product.CarModelId
                };
                model.CarMakes = await carService.CarMakes();
                return View(model);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> BackUpCameras(EditBackUpCameraViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                await backUpCameraService.EditBackUpCamera(model);
                return Redirect($"/Product/Details?productId={model.ProductId}");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
    }
}
