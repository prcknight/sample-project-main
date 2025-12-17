using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> GetAll();
        IEnumerable<Order> Get(string ordernumber = null, string vendor = null);
        void DeleteAll();
    }
}
