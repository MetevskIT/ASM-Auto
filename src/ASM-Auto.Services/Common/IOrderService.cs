﻿using ASM_Auto.Data.Models;
using ASM_Auto.Data.Models.Enums.Order;
using ASM_Auto.ViewModels.Administration.ManageOrders;
using ASM_Auto.ViewModels.Order;

namespace ASM_Auto.Services.Common
{
    public interface IOrderService
    {
        public Task CreateOrder(string userId, string firstName, string lastName, string town, string address, string phoneNumber, List<CartProduct> products);

        public Task<List<OrderViewModel>> GetOrders(string userId);

        public Task<List<ManageOrdersViewModel>> ManageOrders(OrderStatus Status);

        public Task ChangeStatus(int orderId, int statusId);

        public Task<OrderDetailsViewModel> Manage(int Order);

        public Task CancelOrder(int orderId);

    }
}
