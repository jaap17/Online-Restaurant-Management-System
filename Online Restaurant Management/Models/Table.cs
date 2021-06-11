using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Models.Table
{
    public class Table
    {
        public int TableID { get; set; }

        public string customerusername { get; set; }

        [Required(ErrorMessage ="Capacity of the table is required")]
        public int capacity { get; set; }

        public string status { get; set; }
    }
}
