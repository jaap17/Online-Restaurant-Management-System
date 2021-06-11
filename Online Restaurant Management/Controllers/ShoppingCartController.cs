using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using sdp.Models;
using sdp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sdp.Controllers
{
   [Authorize]
    public class ShoppingCartController : Controller
    {

        private readonly IMenuRepository _menuRepository;
        private readonly ShoppingCart _shoppingCart;
        private UserManager<IdentityUser> _userManager;

        public ShoppingCartController(IMenuRepository menuRepository,ShoppingCart shoppingCart,UserManager<IdentityUser> userManager)
        {
            _menuRepository = menuRepository;
            _shoppingCart = shoppingCart;
            _userManager = userManager;
        }

       
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.shoppingCartItems = items;
            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(shoppingCartViewModel);

        }

       
        public RedirectToActionResult AddToShoppingCart(int itemId)
        {
            var selectedItem = _menuRepository.Foods.FirstOrDefault(p=>p.Id==itemId);
            if (selectedItem != null)
            {
                _shoppingCart.AddToCart(selectedItem, 1);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveFromShoppingCart(int itemId)
        { 
            var selectedItem = _menuRepository.Foods.FirstOrDefault(p => p.Id == itemId);
            if (selectedItem != null)
            {
                _shoppingCart.RemoveFromCart(selectedItem);
            }
            return RedirectToAction("Index");
        }
    }
}
