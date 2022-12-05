using ASM_Auto.Services.Common;
using ASM_Auto.Web.ViewModels.AutoAccessories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASM_Auto.Web.Controllers
{
    public class AutoAccessoriesController : BaseController
    {
        private ILedlightsService ledlightsService;
        public AutoAccessoriesController(ILedlightsService ledlightsService)
        {
            this.ledlightsService = ledlightsService;
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
    }
}
