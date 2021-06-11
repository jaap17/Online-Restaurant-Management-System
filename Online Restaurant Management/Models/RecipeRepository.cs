using sdp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Models.Recipes
{
    public class RecipeRepository : IRecipeRepository
    {
        public AppDbContext context;
        public RecipeRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Recipes> GetRecipes(string name)
        {
            IEnumerable<Recipes> recipes = context.Recipes.Where(c => c.RecipeName == name);
            if(recipes.Count() == 0)
            {
                return null;
            }
            return recipes;
        }

        public Recipes GetRecipesById(int id)
        {
            Recipes recipes = context.Recipes.Find(id);
            return recipes;
        }

        public Recipes insertRecipe(Recipes recipes)
        {
            context.Recipes.Add(recipes);
            context.SaveChanges();
            return recipes;
        }
    }
}
