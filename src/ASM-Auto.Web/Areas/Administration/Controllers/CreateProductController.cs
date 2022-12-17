using ASM_Auto.Services.Common;
using ASM_Auto.ViewModels.Administration.CreateProducts;
using Microsoft.AspNetCore.Mvc;

namespace ASM_Auto.Web.Areas.Administration.Controllers
{
    public class CreateProductController : BaseController
    {
        private ILedlightsService ledlightsService;
        private ICarService carService;
        private IMatsService matsService;
        private IFoilService foilService;
        private IAutoshampooService autoshampooService;
        private ICleaningAccessoryService accessoryService;
        private IMultimediaService multimediaService;
        private IBackUpCameraService backUpCameraService; 
        public CreateProductController(
            ILedlightsService ledlightsService, 
            ICarService carService,
            IMatsService matsService,
            IFoilService foilService,
            IAutoshampooService autoshampooService,
            ICleaningAccessoryService accessoryService,
            IMultimediaService multimediaService,
            IBackUpCameraService backUpCameraService
            )
        {
            this.ledlightsService = ledlightsService;
            this.carService = carService;
            this.matsService = matsService;
            this.foilService = foilService;
            this.autoshampooService = autoshampooService;
            this.accessoryService = accessoryService;
            this.multimediaService = multimediaService;
            this.backUpCameraService = backUpCameraService;
        }

        [HttpGet]
        public async Task<IActionResult> CreateLedLights()
        {
            var model = new CreateLedLightViewModel();
            model.LedlightsColors = await ledlightsService.GetLedlightsColors();
            model.LedlightsFormats = await ledlightsService.GetLedlightsFormats();
            model.LedlightsPowers = await ledlightsService.GetLedlightsPower();
            model.LedlightsTypes = await ledlightsService.GetLedlightsTypes();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLedLights(CreateLedLightViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.LedlightsColors = await ledlightsService.GetLedlightsColors();
                model.LedlightsFormats = await ledlightsService.GetLedlightsFormats();
                model.LedlightsPowers = await ledlightsService.GetLedlightsPower();
                model.LedlightsTypes = await ledlightsService.GetLedlightsTypes();
                return View(model);
            }
            try
            {
                await ledlightsService.CreateLedLight(model);
                return RedirectToAction("Index", "Admin");
            }
            catch (Exception)
            {

                return View("Error");
            }
           



        }

        [HttpGet]
        public async Task<IActionResult> CreateMats()
        {
            var model = new CreateMatViewModel ();
             model.MatsTypes = await matsService.MatsTypes();
             model.CarMakes = await carService.CarMakes();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMats(CreateMatViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.MatsTypes = await matsService.MatsTypes();
                model.CarMakes = await carService.CarMakes();
                return View(model);
            }

            try
            {
                await matsService.CreateMat(model);
                return RedirectToAction("Index", "Admin");
            }
            catch (Exception)
            {

                return View("Error");
            }



        }

        [HttpGet]
        public async Task<IActionResult> CreateFoils()
        {
            var model = new EditFoilViewModel();
            model.FoilsPurposes = await foilService.GetFoilsPurposes();
            model.FoilsColors = await foilService.GetFoilsColors();
            model.FoilsTypes = await foilService.GetTypes();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFoils(EditFoilViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.FoilsPurposes = await foilService.GetFoilsPurposes();
                model.FoilsColors = await foilService.GetFoilsColors();
                model.FoilsTypes = await foilService.GetTypes();
                return View(model);
            }

            try
            {
                await foilService.CreateFoil(model);
                return RedirectToAction("Index", "Admin");
            }
            catch (Exception)
            {

                return View("Error");
            }



        }

        [HttpGet]
        public async Task<IActionResult> CreateAutoshampoo()
        {
            var model = new CreateAutoshampooViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAutoshampoo(CreateAutoshampooViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await autoshampooService.CreateAutoshampoo(model);
                return RedirectToAction("Index", "Admin");
            }
            catch (Exception)
            {

                return View("Error");
            }
        }


        [HttpGet]
        public async Task<IActionResult> CreateCleaningAccessories()
        {
            var model = new CreateCleaningAccessories();
            model.cleaningAccessories = await accessoryService.GetCleaningTypes();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCleaningAccessories(CreateCleaningAccessories model)
        {
            if (!ModelState.IsValid)
            {
                model.cleaningAccessories = await accessoryService.GetCleaningTypes();
                return View(model);
            }

            try
            {
               await accessoryService.CreateAccessory(model);
                return RedirectToAction("Index", "Admin");
            }
            catch (Exception)
            {

                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> CreateMultimedia()
        {
            var model = new CreateNavigationViewModel();
            model.CarMakes = await carService.CarMakes();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMultimedia(CreateNavigationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.CarMakes = await carService.CarMakes();
                return View(model);
            }

            try
            {
                 await multimediaService.CreateMultimedia(model);
                return RedirectToAction("Index", "Admin");
            }
            catch (Exception)
            {

                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> CreateBackupCameras()
        {
            var model = new CreateBackupCamerasViewModel();
            model.CarMakes = await carService.CarMakes();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBackupCameras(CreateBackupCamerasViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.CarMakes = await carService.CarMakes();
                return View(model);
            }

            try
            {
                await backUpCameraService.CreateBackUpCamera(model);
                return RedirectToAction("Index", "Admin");
            }
            catch (Exception)
            {

                return View("Error");
            }
        }

    }
}