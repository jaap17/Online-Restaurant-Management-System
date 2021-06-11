using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Models.Recipes
{
    public class Recipes
    {
        public int RecipesId { get; set; }

        [Required(ErrorMessage ="Email is Required")]
        [EmailAddress(ErrorMessage ="Invalid Email ID")]
        public string Email { get; set; }

        [Required]
        public string RecipeName { get; set; }

        [Required(ErrorMessage ="Recipe is required")]
        [MaxLength(5000)]
        public string Recipe { get; set; }
    }
}
