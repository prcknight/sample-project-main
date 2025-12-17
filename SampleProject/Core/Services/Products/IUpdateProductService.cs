using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Products
{
    public interface IUpdateProductService
    {
        void Update(Product product, string name, string description, IEnumerable<string> categories, decimal unitprice,
            decimal quantity, string orderunit, string countunit);
    }
}
