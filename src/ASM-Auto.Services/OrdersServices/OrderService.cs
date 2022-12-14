using ASM_Auto.Data.Models;
using ASM_Auto.Data.Models.Enums.Order;
using ASM_Auto.Data.Repository;
using ASM_Auto.Services.Common;
using ASM_Auto.ViewModels.Order;
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

        public async Task CancelOrder(int orderId)
        {
            var order = await orderRepository.GetAll()
             .Where(x => x.OrderId == orderId)
             .FirstOrDefaultAsync();
            if (order==null)
            {
                throw new ArgumentNullException("Продукта не е намерен!");
            }
            if (order.Status!=OrderStatus.Pending)
            {
                throw new Exception("Поръчката вече е отказана или изпратена!");
            }
            order.Status = OrderStatus.Cancelled;
            await orderRepository.SaveChangesAsync();
            


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
            products.ForEach(x => order.OrderedProducts
            .Add(
                new OrderProduct 
                {
                OrderId = order.OrderId,
                ProductId = x.ProductId,
                ProductCount = x.ProductCount

                }
                ));

            await orderRepository.AddAsync(order);
            await orderRepository.SaveChangesAsync();

        }

        public async Task<List<OrderViewModel>> GetOrders()
        {
            var orderProducts = await orderRepository.GetAll()
                .Include(p => p.OrderedProducts)
                .ThenInclude(p=>p.Product)
                .Select(o=>new OrderViewModel 
                {
                OrderId = o.OrderId,
                Status = o.Status,
                CreateDate = o.OrderedOn,
                Products = o.OrderedProducts
                             .Select(p=>new OrderProductViewModel 
                             { 
                             Title = p.Product.Title,
                             ImageUrl = p.Product.ImageUrl,
                             ProductId = p.ProductId,
                             Quantity = p.ProductCount,
                             Price = p.Product.Price
                             }).ToList()
                })
                .ToListAsync();

            return orderProducts;
        }
    }
}
