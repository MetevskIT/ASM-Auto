using Microsoft.AspNetCore.Mvc;

namespace ASM_Auto.Web.Areas.Administration.Controllers
{
    public class AdminController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
