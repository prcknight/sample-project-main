using BusinessEntities;
using BusinessEntities;
using Common;
using Raven.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    [AutoRegister]
    public class ProductRepository : MemoryRepository<Product>, IProductRepository
    {
        public ProductRepository() : base()
        {
        }

        public IEnumerable<User> Get(UserTypes? userType = null, string name = null, string email = null)
        {
            throw new NotImplementedException();
        }
        
        public IEnumerable<User> GetByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            _documentSession.Clear();
        }

        public IEnumerable<Product> GetAll()
        {
            List<Product> result = new List<Product>();

            foreach (var item in _documentSession)
            {
                result.Add(item.Value);
            }

            return result;
        }
    }
}
