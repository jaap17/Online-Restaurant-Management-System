using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Controllers
{
    public class RecipesController:Controller
    {
        private readonly IRecipeRepository _recipe;
        public RecipesController(IRecipeRepository recipe)
        {
            _recipe = recipe;
        }

        [HttpGet]
        public IActionResult AddRecipe()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRecipe(Recipes rec)
        {
            if(ModelState.IsValid)
            {
                Recipes recipes = _recipe.insertRecipe(rec);
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        [HttpGet]
        public IActionResult SearchRecipe()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchRecipes(string recipename)
        {
            IEnumerable<Recipes> foundrecipe = _recipe.GetRecipes(recipename);
            if(foundrecipe == null)
            {
                ViewBag.ErrorMessage = "Recipe not found";
                return View("NotFound");
            }
            Console.WriteLine("Count:"+ foundrecipe.Count());
            return View("ShowRecipes",foundrecipe);
        }

        
    }
}
