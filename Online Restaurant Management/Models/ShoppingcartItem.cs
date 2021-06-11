using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sdp.Models
{
    public class ShoppingcartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Menu Menu { get; set; }

       // public string Name { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
