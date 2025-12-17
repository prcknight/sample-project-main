using BusinessEntities;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    [AutoRegister]
    public class OrderRepository : MemoryRepository<Order>, IOrderRepository
    {
        public OrderRepository() : base()
        {
        }

        public IEnumerable<Order> Get(string ordernumber = null, string vendor = null)
        {
            List<Order> result = new List<Order>();

            foreach (var order in _documentSession.Values)
            {
                if (!string.IsNullOrEmpty(ordernumber) &&
                    string.Equals(order.OrderNumber, ordernumber, StringComparison.CurrentCultureIgnoreCase))
                {
                    result.Add(order);
                }

                if (!result.Contains(order) && !string.IsNullOrEmpty(vendor) &&
                    string.Equals(order.Vendor, vendor, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(order);
                }
            }

            return result;

        }

        public void DeleteAll()
        {
            _documentSession.Clear();
        }

        public IEnumerable<Order> GetAll()
        {
            List<Order> result = new List<Order>();

            foreach (var item in _documentSession)
            {
                result.Add(item.Value);
            }

            return result;
        }
    }
}
