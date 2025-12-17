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

        public IEnumerable<Product> Get(string name = null, string category = null, string countunit = null)
        {
            List<Product> result = new List<Product>();

            foreach (var product in _documentSession.Values)
            {
                if (!string.IsNullOrEmpty(name) &&
                    string.Equals(product.Name, name, StringComparison.CurrentCultureIgnoreCase))
                {
                    result.Add(product);
                }

                if (!result.Contains(product) && !string.IsNullOrEmpty(category) &&
                    product.Categories.FindIndex(c => c.Equals(category, StringComparison.OrdinalIgnoreCase)) != -1)
                {
                    result.Add(product);
                }

                if (!result.Contains(product) && !string.IsNullOrEmpty(countunit) &&
                    string.Equals(product.CountUnit, countunit, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(product);
                }
            }

            return result;

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
