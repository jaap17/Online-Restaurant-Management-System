using Microsoft.AspNetCore.Mvc;
using sdp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sdp2.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackRepository feedbackRepository;
        private readonly IReplyRepository replyRepository;

        public FeedbackController(IFeedbackRepository feedbackRepository,IReplyRepository replyRepository)
        {
            this.feedbackRepository = feedbackRepository;
            this.replyRepository = replyRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Feedback> feedbacks = feedbackRepository.GetFeedbacks();
            
            return View(feedbacks);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Feedback feedback)
        {
            if(ModelState.IsValid)
            {
                feedback.Reply = "Reply from admin is coming Soon....";
                Feedback feed = feedbackRepository.add(feedback);
                return View("ShowFeedback",feedback);
            }
            return View();
        }

        public IActionResult ViewFeed()
        {
            IEnumerable<Feedback> feedbacks = feedbackRepository.GetFeedbacks();
            for (int i = 0; i < feedbacks.Count(); i++)
            {
                string email = feedbacks.ElementAt(i).Email;
                int id = feedbacks.ElementAt(i).FeedbackId;
                Reply reply = replyRepository.GetReply(email,id);
                if (reply != null)
                {
                    feedbacks.ElementAt(i).Reply = reply.reply;
                    feedbackRepository.Update(feedbacks.ElementAt(i));
                }
            }
            return View(feedbacks);
        }


        

    }
}
