using ASM_Auto.Data.Models;
using ASM_Auto.Services.Common;
using ASM_Auto.ViewModels;
using ASM_Auto.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASM_Auto.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = new HomeViewModel();
            model.Products = await _productService.GetNewestProducts(6);

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AboutUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}