using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.Models.Recipes;
using sdp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sdp2.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentsRepository commentsRepository;
        private readonly IRecipeRepository recipeRepository;

        public CommentsController(ICommentsRepository commentsRepository,IRecipeRepository recipeRepository)
        {
            this.commentsRepository = commentsRepository;
            this.recipeRepository = recipeRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create(int RecipesId)
        {
            ViewBag.Id = RecipesId;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Comments comments,int RecipeId)
        {
            if(ModelState.IsValid)
            {
                Recipes recipe = recipeRepository.GetRecipesById(RecipeId);
                comments.Recipe = recipe;
                commentsRepository.Add(comments);
                return View("ShowComment", comments);
            }
            return View();
        }

        public IActionResult ViewComments(int RecipeId)
        {
            Recipes recipe = recipeRepository.GetRecipesById(RecipeId);
            ViewBag.RecipeName = recipe.RecipeName; 
            IEnumerable<Comments> comments = commentsRepository.GetComments(RecipeId);
            return View(comments);
        }
    }
}
