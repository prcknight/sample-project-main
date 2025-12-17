using BusinessEntities;
using Common;
using Core.Services.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Orders
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class UpdateOrderService : IUpdateOrderService
    {
        public void Update(Order order, string ordernumber, string vendor, IEnumerable<OrderItem> orderitems)
        {
            order.SetOrderNumber(ordernumber);
            order.SetVendor(vendor);
            order.SetOrderItems(orderitems);
        }

        public void AddOrderItems(Order order, IEnumerable<OrderItem> orderitems)
        {
            //order.SetOrderNumber(ordernumber);
            //order.SetVendor(vendor);
            List<OrderItem> tempItems = order.OrderItems;
                tempItems.AddRange(orderitems);
            order.SetOrderItems(tempItems);
        }
    }
}
