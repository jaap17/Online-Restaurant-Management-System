using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sdp2.Models
{
    public class Feedback
    {
        public int FeedbackId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Service { get; set; }

        [Required]
        public string FoodTaste { get; set; }

        [Required]
        public string suggestion { get; set; }

        [Required]
        public int? Cleanliness { get; set; }

        public string Reply { get; set; }
    }
}
