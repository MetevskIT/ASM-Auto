using ASM_Auto.Data.Models.Enums.Order;

namespace ASM_Auto.ViewModels.Administration.ManageOrders
{
    public class AllManageOrdersViewModel
    {
        public OrderStatus Status { get; set; }

        public ICollection<ManageOrdersViewModel> Orders { get; set; } = new List<ManageOrdersViewModel>();
    }
}
