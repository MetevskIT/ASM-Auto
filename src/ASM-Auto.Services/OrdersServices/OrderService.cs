using ASM_Auto.Data.Models;
using ASM_Auto.Data.Repository;
using ASM_Auto.Services.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Services.OrdersServices
{
     public class OrderService : IOrderService
    {
        private IRepository<Order> orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task CreateOrder(string userId, string firstName, string lastName, string town, string address, string phoneNumber, List<CartProduct> products)
        {
            var order = new Order
            {
                UserId = userId,
                FirstName = firstName,
                LastName = lastName,
                Town = town,
                Address = address,
                PhoneNumber = phoneNumber
            };
            products.ForEach(x => order.OrderedProducts.Add(x));

            await orderRepository.AddAsync(order);
            await orderRepository.SaveChangesAsync();

        }


    }
}
