using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.Products
{
    public class ProductModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Categories { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public string OrderUnit { get; set; }
        public string CountUnit { get; set; }
    }
}