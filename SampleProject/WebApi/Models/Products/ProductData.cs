using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Xml.Linq;

namespace WebApi.Models.Products
{
    public class ProductData : IdObjectData
    {
        public ProductData(Product product) : base(product)
        {
            Name = product.Name;
            Description = product.Description;
            Categories = product.Categories;
            UnitPrice = product.UnitPrice;
            Quantity = product.Quantity;
            OrderUnit = product.OrderUnit;
            CountUnit = product.CountUnit;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Categories { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public string OrderUnit { get; set; }
        public string CountUnit { get; set; }
    }
}