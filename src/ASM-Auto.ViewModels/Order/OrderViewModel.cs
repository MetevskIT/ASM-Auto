using ASM_Auto.Data.Models.Enums.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.ViewModels.Order
{
    public class OrderViewModel
    {
        [Required]
        public int OrderId { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        public ICollection<OrderProductViewModel> Products { get; set; } = new List<OrderProductViewModel>();
    }
}
