using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sdp.ViewModels
{
    public class MenuCreateViewModel
    {
        [Required]
        public string Name { get; set; }


        public IFormFile Photo { get; set; }
        public string Ingredients { get; set; }
        public double Price { get; set; }


        public string Category { get; set; }

    }
}
