using ASM_Auto.Data.Models;
using ASM_Auto.Data.Models.Enums.Order;
using ASM_Auto.Data.Repository;
using ASM_Auto.Services.Common;
using ASM_Auto.ViewModels.Administration.ManageOrders;
using ASM_Auto.ViewModels.Order;
using Microsoft.EntityFrameworkCore;

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

            if (order == null)
            {
                throw new ArgumentNullException("Продукта не е намерен!");
            }

            if (order.Status != OrderStatus.Pending)
            {
                throw new Exception("Поръчката вече е отказана или изпратена!");
            }

            order.Status = OrderStatus.Cancelled;
            await orderRepository.SaveChangesAsync();
        }

        public async Task ChangeStatus(int orderId, int statusId)
        {
            var order = await orderRepository.GetAll()
              .Include(s => s.Status)
              .Where(x => x.OrderId == orderId)
              .FirstOrDefaultAsync();

            if (order == null)
            {
                throw new ArgumentNullException("Продукта не е намерен!");
            }

            if (order.Status != OrderStatus.Pending)
            {
                throw new Exception("Поръчката вече е отказана или изпратена!");
            }

            order.Status = (OrderStatus)statusId;
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
            .Add(new OrderProduct
            {
                OrderId = order.OrderId,
                ProductId = x.ProductId,
                ProductCount = x.ProductCount
            }));

            await orderRepository.AddAsync(order);
            await orderRepository.SaveChangesAsync();
        }

        public async Task<List<OrderViewModel>> GetOrders(string userId)
        {
            var orderProducts = await orderRepository.GetAll()
                .Include(p => p.OrderedProducts)
                .ThenInclude(p => p.Product)
                .ThenInclude(i => i.Images)
                .Where(u => u.UserId == userId)
                .Select(o => new OrderViewModel
                {
                    OrderId = o.OrderId,
                    Status = o.Status,
                    CreateDate = o.OrderedOn,
                    Products = o.OrderedProducts
                             .Select(p => new OrderProductViewModel
                             {
                                 Title = p.Product.Title,
                                 ImageUrl = p.Product.Images.FirstOrDefault().ImageUrl,
                                 ProductId = p.ProductId,
                                 Quantity = p.ProductCount,
                                 Price = p.Product.Price
                             }).ToList()
                })
                .ToListAsync();

            return orderProducts;
        }

        public async Task<OrderDetailsViewModel> Manage(int Order)
        {
            var orderProducts = await orderRepository.GetAll()
               .Where(i => i.OrderId == Order)
               .Include(p => p.OrderedProducts)
               .ThenInclude(p => p.Product)
               .ThenInclude(i => i.Images)
               .FirstOrDefaultAsync();
            var result = new OrderDetailsViewModel
            {
                FirstName = orderProducts.FirstName,
                LastName = orderProducts.LastName,
                Address = orderProducts.Address,
                Town = orderProducts.Town,
                PhoneNumber = orderProducts.PhoneNumber,
                OrderId = orderProducts.OrderId,
                Status = orderProducts.Status,
                CreateDate = orderProducts.OrderedOn,
                Products = orderProducts.OrderedProducts
                             .Select(p => new OrderProductViewModel
                             {
                                 Title = p.Product.Title,
                                 ImageUrl = p.Product.Images.FirstOrDefault().ImageUrl,
                                 ProductId = p.ProductId,
                                 Quantity = p.ProductCount,
                                 Price = p.Product.Price
                             }).ToList()
            };

            return result;
        }

        public async Task<List<ManageOrdersViewModel>> ManageOrders(OrderStatus Status)
        {
            var orderProducts = await orderRepository.GetAll()
                .Where(s => s.Status == Status)
                .Include(u => u.User)
                .Include(p => p.OrderedProducts)
                .ThenInclude(p => p.Product)
                .ThenInclude(i => i.Images)
                .Select(o => new ManageOrdersViewModel
                {
                    FirstName = o.FirstName,
                    LastName = o.LastName,
                    OrderId = o.OrderId,
                    Status = o.Status,
                    CreateDate = o.OrderedOn,
                    Products = o.OrderedProducts
                             .Select(p => new OrderProductViewModel
                             {
                                 Title = p.Product.Title,
                                 ImageUrl = p.Product.Images.FirstOrDefault().ImageUrl,
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
