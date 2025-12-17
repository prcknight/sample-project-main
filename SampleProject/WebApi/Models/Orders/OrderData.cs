using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebApi.Models.Orders
{
    public class OrderData : IdObjectData
    {
        public OrderData(Order order) : base(order)
        {
            OrderNumber = order.OrderNumber;
            Vendor = order.Vendor;
            OrderItems = order.OrderItems;
        }

        public string OrderNumber { get; set; }
        public string Vendor { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}