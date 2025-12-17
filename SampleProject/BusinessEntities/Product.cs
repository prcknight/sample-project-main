using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Common.Extensions;

namespace BusinessEntities
{
    public class Product : IdObject
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<string> Categories { get; set; } = new List<string>();

        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }

        public string OrderUnit { get; set; }
        public string CountUnit { get; set; }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name was not provided.");
            }
            Name = name;
        }

        public void SetDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException("Description was not provided.");
            }
            Description = description;
        }

        public void SetCategories(IEnumerable<string> categories)
        {
            Categories.Initialize(categories);
        }

        public void SetUnitPrice(decimal unitprice)
        {
            if (unitprice < 0.0m)
            {
                throw new ArgumentNullException("Name was not provided.");
            }
            UnitPrice = unitprice;
        }

        public void SetQuantity(decimal quantity)
        {
            if (quantity < 0.0m)
            {
                throw new ArgumentNullException("Name was not provided.");
            }
            Quantity = quantity;
        }

        public void SetOrderUnit(string orderunit)
        {
            if (string.IsNullOrEmpty(orderunit))
            {
                throw new ArgumentNullException("Name was not provided.");
            }
            OrderUnit = orderunit;
        }

        public void SetCountUnit(string countunit)
        {
            if (string.IsNullOrEmpty(countunit))
            {
                throw new ArgumentNullException("Name was not provided.");
            }
            CountUnit = countunit;
        }

        public decimal TotalValue => UnitPrice * Quantity;
    }
}
