using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sdp.Models;

namespace sdp.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly UserManager<IdentityUser> _usermanager;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly AppDbContext _context;
        private readonly string _username;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ShoppingCart _shoppingCart;


        public OrderRepository(AppDbContext context, ShoppingCart shoppingCart, IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _shoppingCart = shoppingCart;
            _httpContextAccessor = httpContextAccessor;
            _username = httpContextAccessor.HttpContext.User.Identity.Name;
            _usermanager = userManager;
        }


        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

           
            var shoppingCartItems = _shoppingCart.shoppingCartItems;
            foreach (var shoppingcartitemss in shoppingCartItems)
            {

                order.OrderName = shoppingcartitemss.Menu.Name;
                order.orderedby = _username;
                order.Status = false;
                order.OrderTotal = (double)_shoppingCart.GetShoppingCartTotal();
                _context.Orderrs.Add(order);
            }
            

            _context.SaveChanges();

            foreach (var shoppingCartItem in shoppingCartItems)
                {
                var orderDetail = new OrderDetail()
                {

                    Amount = shoppingCartItem.Amount,
                    MenuId = shoppingCartItem.Menu.Id,
                    OrderId = order.OrderId,
                    Price = shoppingCartItem.Menu.Price,
                    OrderName = shoppingCartItem.Menu.Name,
                    orderedby = _username,
                    Status = false,
                    OrderPlaced = order.OrderPlaced



                    };


                    _context.OrderDetails.Add(orderDetail);
                    
                }

                _context.SaveChanges();
            }

        

        public IEnumerable<Order> GetAllOrder()
        {
            return _context.Orderrs.OrderByDescending(s => s.OrderId);
        }

        public Order GetOrderId(int id)
        {
            return _context.Orderrs.Where(i => i.OrderId == id).FirstOrDefault();
        }

        public Order Update(Order ItemChanges)
        {
            var Orderr = _context.Orderrs.Attach(ItemChanges);
            Orderr.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return ItemChanges;
        }

        public IEnumerable<Order> GetOrder()
        {
            return _context.Orderrs.Where(s => s.Status == false);
        }
    }
       
    }
