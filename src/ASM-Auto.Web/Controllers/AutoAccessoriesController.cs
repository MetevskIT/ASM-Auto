using ASM_Auto.Services.AutoAccessoriesServices;
using ASM_Auto.Services.Car;
using ASM_Auto.Services.Common;
using ASM_Auto.ViewModels.AutoAccessories.Foils;
using ASM_Auto.ViewModels.AutoAccessories.LedLights;
using ASM_Auto.ViewModels.AutoAccessories.Mats;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASM_Auto.Web.Controllers
{
    public class AutoAccessoriesController : BaseController
    {
        private ILedlightsService ledlightsService;
        private ICarService carService;
        private IMatsService matsService;
        private IFoilService foilService;
        public AutoAccessoriesController(ILedlightsService ledlightsService,ICarService carService, IMatsService matsService, IFoilService foilService)
        {
            this.ledlightsService = ledlightsService;
            this.matsService = matsService;
            this.carService = carService;
            this.foilService = foilService;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Ledlights([FromQuery]AllLedlightsQueryModel queryModel)
        {
             
            var products = await ledlightsService.GetLedlights(
                queryModel.currentPage,
                queryModel.LedlightsType,
                queryModel.LedlightsColor,
                queryModel.LedlightsPower,
                queryModel.LedlightsFormat,
                queryModel.OrderedProducts);

            queryModel.LedlightsCount = await ledlightsService.GetLedlightsCount();
            queryModel.LedlightsFormats = await ledlightsService.GetLedlightsFormats();
            queryModel.LedlightsPowers = await ledlightsService.GetLedlightsPower();
            queryModel.LedlightsColors = await ledlightsService.GetLedlightsColors();
            queryModel.LedlightsTypes = await ledlightsService.GetLedlightsTypes();
            queryModel.Ledlights = products;
            return View(queryModel);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Mats([FromQuery] AllMatsViewModel queryModel)
        {

            queryModel.MatsCount = await matsService.MatsCount();
            queryModel.CarMakes = await carService.CarMakes();
            queryModel.MatsTypes = await matsService.MatsTypes();
            queryModel.Mats = await matsService.GetMats(queryModel.currentPage,queryModel.CarMakeId,queryModel.CarModelId,queryModel.MatsTypeId,queryModel.OrderedProducts);

            return View(queryModel);
        }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> Foils([FromQuery] AllFoilsQueryModel queryModel)
    {

        queryModel.FoilsPurposes = await foilService.GetFoilsPurposes();
        queryModel.FoilsTypes = await foilService.GetTypes();
        queryModel.FoilsColors = await foilService.GetFoilsColors();
        queryModel.FoilsCount = await foilService.GetFoilsCount();
            queryModel.Foils = await foilService.GetFoils(queryModel.currentPage,queryModel.FoilsTypeId,queryModel.FoilsColorId,queryModel.FoilsPurposeId,queryModel.OrderedProducts);

        return View(queryModel);
    }



}
}
