using Microsoft.AspNetCore.Mvc;

namespace ASM_Auto.Web.Areas.Administration.Controllers
{
    public class ManageOrders : Controller
    {
        public IActionResult AllOrders()
        {
            return View();
        }
    }
}
