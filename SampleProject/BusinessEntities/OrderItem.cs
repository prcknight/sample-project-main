using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessEntities
{
    public class OrderItem : IdObject
    {
        //public string ProductId { get; set; }
        public Product Product { get; set; }
        public string OrderUnit { get; set; }

        public decimal Quantity { get; set; }
        public decimal Price { get; set; }

        public decimal ExtendedPrice => Quantity * Price;
    }
}
