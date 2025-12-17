using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessEntities;

namespace WebApi.Models.Orders
{
    public class OrderModel
    {
        public string OrderNumber { get; set; }
        public string Vendor { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}