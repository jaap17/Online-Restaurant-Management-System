using RestaurantManagementSystem.Models.Recipes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sdp2.Models
{
    public class Comments
    {
        public int CommentsId { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Comment { get; set; }

        public Recipes Recipe { get; set; }
    }
}
