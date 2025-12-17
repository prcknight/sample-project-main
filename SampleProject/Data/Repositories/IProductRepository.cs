using System;
using System.Collections.Generic;
using System.Text;
using BusinessEntities;

namespace Data.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetAll();
        //IEnumerable<User> Get(UserTypes? userType = null, string name = null, string email = null);
        //IEnumerable<User> GetByCategory(string category);
        void DeleteAll();
    }
}
