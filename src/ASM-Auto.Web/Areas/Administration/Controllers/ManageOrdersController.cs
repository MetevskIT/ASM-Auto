using ASM_Auto.Data.Models.Enums.Order;
using ASM_Auto.Services.Common;
using ASM_Auto.ViewModels.Administration.ManageOrders;
using Microsoft.AspNetCore.Mvc;

namespace ASM_Auto.Web.Areas.Administration.Controllers
{
    public class ManageOrdersController : BaseController
    {
        private IOrderService orderService;
        public ManageOrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> AllOrders(OrderStatus Status=OrderStatus.Pending)
        {
            var model = new AllManageOrdersViewModel();
            model.Orders = await orderService.ManageOrders(Status);
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Manage([FromQuery]int Order)
        {
            var model = await orderService.Manage(Order);
           
            return View(model);
        }
    }
}
