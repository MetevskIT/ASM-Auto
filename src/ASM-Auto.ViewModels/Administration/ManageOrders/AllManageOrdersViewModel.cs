using ASM_Auto.Data.Models.Enums.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.ViewModels.Administration.ManageOrders
{
    public class AllManageOrdersViewModel
    {
        public OrderStatus Status { get; set; }
        public ICollection<ManageOrdersViewModel> Orders { get; set; } = new List<ManageOrdersViewModel>();
    }
}
