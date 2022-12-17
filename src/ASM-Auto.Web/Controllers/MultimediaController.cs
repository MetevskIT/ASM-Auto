using ASM_Auto.Services.Common;
using ASM_Auto.ViewModels.Multimedia;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASM_Auto.Web.Controllers
{
    public class MultimediaController : BaseController
    {
        private ICarService carService;
        private IMultimediaService multimediaService;
        private IBackUpCameraService cameraService;
        public MultimediaController(ICarService carService, IMultimediaService multimediaService, IBackUpCameraService cameraService)
        {
            this.carService = carService;
            this.multimediaService = multimediaService;
            this.cameraService = cameraService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Multimedia([FromQuery]MultimediaQueryModel queryModel)
        {
            queryModel.CarMakes = await carService.CarMakes();
            queryModel.Products = await multimediaService.GetProducts(queryModel.currentPage,queryModel.CarMakeId,queryModel.CarModelId,queryModel.OrderedProducts);
            queryModel.ProductCount = await multimediaService.ProductCount();

            return View(queryModel);
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> BackupCameras([FromQuery] MultimediaQueryModel queryModel)
        {
            queryModel.CarMakes = await carService.CarMakes();
            queryModel.Products = await cameraService.GetProducts(queryModel.currentPage, queryModel.CarMakeId, queryModel.CarModelId, queryModel.OrderedProducts);
            queryModel.ProductCount = await cameraService.ProductCount();

            return View(queryModel);
        }
    }
}
