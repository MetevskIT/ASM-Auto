using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Models.Enums.Order
{
    public enum OrderStatus
    {
        Pending,
        Declined,
        Confirmed,
        Shipped,
        Completed,
        Cancelled
    }
}
