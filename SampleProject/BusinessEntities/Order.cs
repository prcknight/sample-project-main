using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Common.Extensions;

namespace BusinessEntities
{
    public class Order : IdObject
    {
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public string OrderNumber { get; set; }
        public string Vendor { get; set; }

        public void SetOrderNumber(string ordernumber)
        {
            if (string.IsNullOrEmpty(ordernumber))
            {
                throw new ArgumentNullException("Order number was not provided.");
            }

            OrderNumber = ordernumber;
        }

        public void SetVendor(string vendor)
        {
            if (string.IsNullOrEmpty(vendor))
            {
                throw new ArgumentNullException("Vendor was not provided.");
            }
            Vendor = vendor;
        }

        public void SetOrderItems(IEnumerable<OrderItem> orderitems)
        {
            OrderItems.Initialize(orderitems);
        }

    }
}
