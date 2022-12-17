using ASM_Auto.Services.Common;
using ASM_Auto.ViewModels.Administration.CreateProducts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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
