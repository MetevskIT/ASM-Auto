using ASM_Auto.Services.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASM_Auto.Web.Controllers
{
    public class CarController : BaseController
    {
        private ICarService carService;
        public CarController(ICarService carService)
        {
            this.carService = carService;
        }
        [AllowAnonymous]
        public async Task<JsonResult> GetCarModels(int carMakeId)
        {
            var models = await carService.CarModels(carMakeId);

            return Json(models);
        }
    }
}
