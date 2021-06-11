using Microsoft.AspNetCore.Mvc.ModelBinding;
using sdp2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace sdp.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }

        public string OrderName { get; set; }

        public string orderedby { get; set; }

        public DateTime OrderPlaced { get; set; }
        public int MenuId { get; set; }
        public int Amount { get; set; }

      

     
        public double Price { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual Order Order { get; set; }

        public Boolean Status { get; set; }

        public OrderDetail()
            {
            Status = false;
                
            }
       
    }
}
