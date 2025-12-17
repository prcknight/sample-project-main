using BusinessEntities;
using Core.Factories;
using Core.Services.Orders;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class CreateOrderService : ICreateOrderService
    {
        private readonly IUpdateOrderService _updateOrderService;
        private readonly IIdObjectFactory<Order> _orderFactory;
        private readonly IOrderRepository _orderRepository;

        public CreateOrderService(IIdObjectFactory<Order> orderFactory, IOrderRepository orderRepository, IUpdateOrderService updateOrderService)
        {
            _orderFactory = orderFactory;
            _orderRepository = orderRepository;
            _updateOrderService = updateOrderService;
        }

        public Order Create(Guid id, string ordernumber, string vendor, IEnumerable<OrderItem> orderitems)
        {
            var order = _orderFactory.Create(id);
            _updateOrderService.Update(order, ordernumber, vendor, orderitems);
            _orderRepository.Save(order);
            return order;
        }
    }
}
