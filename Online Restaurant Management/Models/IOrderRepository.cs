using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sdp.Models
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);

        IEnumerable<Order> GetAllOrder();

        IEnumerable<Order> GetOrder();

        Order GetOrderId(int id);

        Order Update(Order ItemChanges);






    }
}
