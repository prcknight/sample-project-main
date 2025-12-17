using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Products
{
    public interface ICreateProductService
    {
        Product Create(Guid id, string name, string description, IEnumerable<string> categories, decimal unitprice, 
            decimal quantity, string orderunit, string countunit);
    }
}
