using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Models.Recipes
{
    public interface IRecipeRepository
    {
        public Recipes insertRecipe(Recipes recipes);

        public IEnumerable<Recipes> GetRecipes(string name);

        public Recipes GetRecipesById(int id);
    }
}
