using sdp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sdp2.Models
{
    public class OrderDetailRepository : IOrderDetailRepository
    {

        private readonly AppDbContext _context;

        public OrderDetailRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<OrderDetail> GetOrder(int id)
        {
            var row = from input in _context.OrderDetails.AsEnumerable()
                      where input.OrderId == id
                      select input;
          
            return row;


        }

        public List<OrderDetail> GetOrderId(int id)
        {

            return _context.OrderDetails.Where(s => s.OrderId == id).ToList();
        }

        public IEnumerable<OrderDetail> MyOrder(String email)
        {
            return _context.OrderDetails.OrderByDescending(s => s.OrderId).Where(e => e.orderedby == email);
        }

        public OrderDetail Update(OrderDetail ItemChanges)
        {
            var Order = _context.OrderDetails.Attach(ItemChanges);
            Order.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return ItemChanges;
        }
    }
}
