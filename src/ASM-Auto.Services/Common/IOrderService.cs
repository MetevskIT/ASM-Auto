using ASM_Auto.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Services.Common
{
    public interface IOrderService
    {
        public Task CreateOrder(string userId, string firstName, string lastName, string town, string address, string phoneNumber, List<CartProduct> products);

    }
}
