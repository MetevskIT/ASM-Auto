using ASM_Auto.Data.Models.Enums.Order;
using ASM_Auto.ViewModels.Order;
using System.ComponentModel.DataAnnotations;

namespace ASM_Auto.ViewModels.Administration.ManageOrders
{
    public class OrderDetailsViewModel
    {
        [Required]
        public int OrderId { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public string? Town { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public ICollection<OrderProductViewModel> Products { get; set; } = new List<OrderProductViewModel>();
    }
}
