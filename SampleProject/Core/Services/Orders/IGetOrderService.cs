using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Orders
{
    public interface IGetOrderService
    {
        Order GetOrder(Guid id);

        IEnumerable<Order> GetAllOrders();
        IEnumerable<Order> GetOrders(string ordernumber = null, string vendor = null);
    }
}
