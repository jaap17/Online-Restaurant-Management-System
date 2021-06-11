using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using sdp.Models;
using sdp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sdp.ViewModels;
using MimeKit;
using System.Text;

namespace sdp.Controllers
{
    
    public class OrderController : Controller
    {

        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderdetailRepository;
        private readonly ShoppingCart _shoppingCart;
        private readonly string _username;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart,IOrderDetailRepository orderDetailRepository, IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager)
        {
            _orderRepository = orderRepository;
            _orderdetailRepository = orderDetailRepository;
            _shoppingCart = shoppingCart;
            _httpContextAccessor = httpContextAccessor;
            _username = httpContextAccessor.HttpContext.User.Identity.Name;
            

        }
        public IActionResult CheckOut()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            
        var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.shoppingCartItems = items;
            if (_shoppingCart.shoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your card is empty, add some items first");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }

            return View(order);
        }


        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order! :) ";
            return View();
        }

        [Authorize(Roles ="Admin,Chef")]
        public IActionResult GetAllOrders()
        {
            var items = _orderRepository.GetAllOrder();
            return View(items);
        }

        [Authorize(Roles = "Admin,Chef")]


        public IActionResult OrderDetails(int id)
        {


            var food = _orderdetailRepository.GetOrder(id);

           
            
            
           
            

            //OrderDetail items = _orderRepository.GetOrder(id);
            //return View(items);

            


            return View(food);

        }

        public IActionResult MyOrder()
        {


            

            var food = _orderdetailRepository.MyOrder(_username);

            //OrderDetail model = food;

            return View(food);

            //OrderDetail items = _orderRepository.GetOrder(id);
            //return View(items);




        }
        [Authorize(Roles = "Admin,Chef")]

        [HttpGet]
        public ViewResult ChangeStatus(int id)

        {
            Order food = _orderRepository.GetOrderId(id);

            OrderDetail order = new OrderDetail
            {
                Status = food.Status,
                OrderId = food.OrderId,
                orderedby = food.orderedby

            };
            return View(order);

        }
        [Authorize(Roles = "Admin,Chef")]


        [HttpPost]
        public IActionResult ChangeStatus(OrderDetail model)
        {

            Order food = _orderRepository.GetOrderId(model.OrderId);

            food.Status = model.Status;
            _orderRepository.Update(food);


            if (food.Status == true)
            {
                Index(model.OrderId);
            }

            var item = _orderdetailRepository.GetOrderId(model.OrderId);
            foreach(var it in item)
            {
                if (food.Status == true)
                {

                    it.Status = true;
                    _orderdetailRepository.Update(it);
                    
                }
                else
                {
                    it.Status =false;
                    _orderdetailRepository.Update(it);
                }
            }

            
            


          //foreach(var it in item)

          //  {
          //      it.Status = true;

          //      _orderdetailRepository.Update(it);
          //  }
           



            return RedirectToAction("GetAllorders");
        }

        [Authorize(Roles = "Admin,Chef")]

        public ViewResult PendingOrders()
        {
            var items = _orderRepository.GetOrder();

            return View(items);
        }

        public string OrderDetailsConfirmation(int id)
        {
            System.Text.StringBuilder sb = new StringBuilder();

            sb.Append("<html>");

            sb.Append("<table border='1'>");
            sb.Append("<th>OrderName</th>");
            sb.Append("<th>Amount</th>");
            sb.Append("<th>Price</th>");



            foreach (var od in _orderdetailRepository.GetOrder(id))
            {
                sb.Append("<tr><td>" + od.OrderName + "</td>");
                sb.Append("<td>" + od.Amount + "</td>");
                sb.Append("<td>" + od.Price + "</td>");



            }
            sb.Append("</html>");

            sb.Append("</table>");
            return sb.ToString();
        }

        public IActionResult Index(int id)
        {

            var food = _orderRepository.GetOrderId(id);
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Stellar Kitchen", "stellarkitchen356@gmail.com"));
            message.To.Add(new MailboxAddress("", food.orderedby));
            message.Subject = "Stellar Kitchen Order Confirmation";

            message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = "Your Order is Accepted.Here are Your Order Details" + OrderDetailsConfirmation(id) + "Order Total:Rs." + food.OrderTotal + "<br/>" + "Order Id:" + food.OrderId


            };




            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("stellarkitchen356@gmail.com", "Stellar@123456");
                client.Send(message);
                client.Disconnect(true);
            }

            return View();
        }


    }
}