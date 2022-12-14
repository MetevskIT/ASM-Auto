using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.ViewModels.Order
{
    public class AllOrders
    {
        public ICollection<OrderViewModel> Orders { get; set; } = new List<OrderViewModel>();
    }
}
