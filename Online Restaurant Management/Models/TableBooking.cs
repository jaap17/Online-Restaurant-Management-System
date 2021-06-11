using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Models.TableBooking
{
    public class TableBooking
    {
        public int TableBookingId { get; set; }
        
        [Required(ErrorMessage ="Email is required")]
        [EmailAddress(ErrorMessage ="Invalid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Data of booking is required")]
        public DateTime AppointmentDateTime { get; set; }

        [Required(ErrorMessage ="Persons for which the booking is to be done is required")]
        public int Numberofpersons { get; set; }
    }
}
