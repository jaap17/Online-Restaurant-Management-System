using sdp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sdp2.Models
{
    public interface IOrderDetailRepository
    {

       IEnumerable<OrderDetail> GetOrder(int id);

       
      List<OrderDetail> GetOrderId(int id);
        IEnumerable<OrderDetail> MyOrder(string email);

        OrderDetail Update(OrderDetail ItemChanges);
    }
}
