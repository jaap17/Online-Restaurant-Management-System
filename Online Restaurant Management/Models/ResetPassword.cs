using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sdp2.Models
{
    public class ResetPassword
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="New Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]

        [Display(Name = "Confirm New Password")]
        [Compare("Password", ErrorMessage = "Password and Confirm password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }
        public string Token { get; set; }
    }
}
