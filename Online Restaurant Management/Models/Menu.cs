using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sdp.Models
{
    public class Menu
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }



        public string PhotoPath { get; set; }

        public string Ingredients { get; set; }
        public double Price { get; set; }


        public string Category { get; set; }
    }
}
