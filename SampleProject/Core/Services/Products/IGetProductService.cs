using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Products
{
    public interface IGetProductService
    {
        Product GetProduct(Guid id);

        IEnumerable<Product> GetAllProducts();
        //IEnumerable<User> GetUsers(UserTypes? userType = null, string name = null, string email = null);
        //IEnumerable<User> GetUsersByTag(string tag = null);
    }
}
