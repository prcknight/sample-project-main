using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Orders
{
    public interface IUpdateOrderService
    {
        void Update(Order product, string ordernumber, string vendor, IEnumerable<OrderItem> orderitems);
        void AddOrderItems(Order order, IEnumerable<OrderItem> orderitems);
    }
}
