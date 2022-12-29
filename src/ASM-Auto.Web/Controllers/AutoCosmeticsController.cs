using ASM_Auto.Services.Common;
using ASM_Auto.ViewModels.AutoCosmetics.Autoshampoo;
using ASM_Auto.ViewModels.AutoCosmetics.CleaningAccessories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASM_Auto.Web.Controllers
{
    public class AutoCosmeticsController : BaseController
    {   
        private IAutoshampooService autoshampooService;
        private ICleaningAccessoryService accessoryService;
        public AutoCosmeticsController(
            IAutoshampooService autoshampooService,
            ICleaningAccessoryService accessoryService)
        {
            this.autoshampooService = autoshampooService;
            this.accessoryService = accessoryService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Autoshampoo([FromQuery] AllAutoshampooQuery queryModel)
        {
            queryModel.Shampoos = await autoshampooService.GetShampoos(queryModel.currentPage, queryModel.OrderedProducts);
            queryModel.ShampoosCount = await autoshampooService.GetShampooCount();

            return View(queryModel);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> CleaningAccessories([FromQuery] CleaningAccessoriesQueryModel queryModel)
        {
            queryModel.AccessoriesType = await accessoryService.GetCleaningTypes();
            queryModel.AccessoriesCount = await accessoryService.GetAccessoriesCount();
            queryModel.Accessories = await accessoryService.GetCleaningAccesories(queryModel.currentPage, queryModel.AccessoriesTypeId, queryModel.OrderedProducts);

            return View(queryModel);
        }
    }
}
