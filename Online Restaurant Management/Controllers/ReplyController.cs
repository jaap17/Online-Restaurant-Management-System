using Microsoft.AspNetCore.Mvc;
using sdp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sdp2.Controllers
{
    public class ReplyController : Controller
    {
        private readonly IReplyRepository replyRepository;
        private readonly IFeedbackRepository feedbackRepository;

        public ReplyController(IReplyRepository replyRepository,IFeedbackRepository feedbackRepository)
        {
            this.replyRepository = replyRepository;
            this.feedbackRepository = feedbackRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(string Email,int FeedbackId)
        {
            if(Email == null)
            {
                ViewBag.Email = "No Email";
            }
            else
            {
                ViewBag.Email = Email;
                ViewBag.Id = FeedbackId;
            }
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(Reply answer)
        {
            if(ModelState.IsValid)
            {
                Reply reply = replyRepository.Add(answer);
                
                return View("Reply",reply);
            }
            return View();
        }
    }
}
