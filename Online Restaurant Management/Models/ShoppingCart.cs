using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sdp.Models
{
    public class ShoppingCart
    {
        private readonly AppDbContext context;

        public ShoppingCart(AppDbContext context)
        {
            this.context = context;
        }
        public string ShoppingCartId { get; set; }

        public List<ShoppingcartItem> shoppingCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<AppDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Menu menu, int amount)
        {
            var shoppingCartItem =
                    context.ShoppingCartItems.SingleOrDefault(
                        s => s.Menu.Id == menu.Id && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingcartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Menu = menu,
                    Amount = 1,
                   
                 
                };

                context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            context.SaveChanges();
        }
        public int RemoveFromCart(Menu menu)
        {
            var shoppingCartItem =
                    context.ShoppingCartItems.SingleOrDefault(
                        s => s.Menu.Id == menu.Id && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

           context.SaveChanges();

            return localAmount;
        }
        public List<ShoppingcartItem> GetShoppingCartItems()
        {
            return shoppingCartItems ??
                   (shoppingCartItems =
                       context.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Menu)
                           .ToList());
        }

        public void ClearCart()
        {
            var cartItems = context
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            context.ShoppingCartItems.RemoveRange(cartItems);

            context.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = context.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Menu.Price * c.Amount).Sum();
            return (decimal)total;
        }
    }
}
