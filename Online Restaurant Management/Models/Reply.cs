using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sdp2.Models
{
    public class Reply
    {

        public int ReplyId { get; set; }

        public int FeedbackId { get; set; }
       
        public string FeedbackEmail { get; set; }

        [Required]
        public string reply { get; set; }
    }
}
