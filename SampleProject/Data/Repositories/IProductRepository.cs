using System;
using System.Collections.Generic;
using System.Text;
using BusinessEntities;

namespace Data.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetAll();
        IEnumerable<Product> Get(string name = null, string category = null, string countunit = null);
        void DeleteAll();
    }
}
