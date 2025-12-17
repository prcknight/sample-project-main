using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Orders
{
    public interface ICreateOrderService
    {
        Order Create(Guid id, string ordernumber, string vendor, IEnumerable<OrderItem> orderitems);
    }
}
