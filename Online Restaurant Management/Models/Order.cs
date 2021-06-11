using Microsoft.AspNetCore.Mvc.ModelBinding;
using sdp2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sdp.Models
{
    public class Order
    {
        
        public int OrderId { get; set; }

        public List<OrderDetail> OrderLines { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your address")]
        [StringLength(100)]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Please enter your zip code")]
        [Display(Name = "Zip code")]
        [StringLength(10, MinimumLength = 4)]
        public string ZipCode { get; set; }

        [Required]

        public string City { get; set; }

       

        [Required(ErrorMessage = "Please enter your phone number")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

       

        [BindNever]
        [ScaffoldColumn(false)]
        public double OrderTotal { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderPlaced { get; set; }

        public string OrderName { get; set; }

        public string orderedby { get; set; }

        public Boolean Status { get; set; }

        public Order()
        {
            Status = false;
        }

    }
}
