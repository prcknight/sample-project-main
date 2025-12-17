using BusinessEntities;
using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Products
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class UpdateProductService : IUpdateProductService
    {
        public void Update(Product product, string name, string description, IEnumerable<string> categories,
            decimal unitprice,
            decimal quantity, string orderunit, string countunit)
        {
            product.SetName(name);
            product.SetDescription(description);
            product.SetCategories(categories);
            product.SetUnitPrice(unitprice);
            product.SetQuantity(quantity);
            product.SetOrderUnit(orderunit);
            product.SetCountUnit(countunit);
        }
    }
}
