namespace ASM_Auto.ViewModels.Order
{
    public class AllOrders
    {
        public ICollection<OrderViewModel> Orders { get; set; } = new List<OrderViewModel>();

    }
}
