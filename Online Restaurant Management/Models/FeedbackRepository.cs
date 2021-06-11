using sdp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sdp2.Models
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly AppDbContext context;

        public FeedbackRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Feedback add(Feedback feedback)
        {
            context.feedbacks.Add(feedback);
            context.SaveChanges();
            return feedback;
        }

        public IEnumerable<Feedback> GetFeedbacks()
        {
            return context.feedbacks;
        }

        public Feedback Update(Feedback feedback)
        {
            var feed = context.feedbacks.Attach(feedback);
            feed.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return feedback;
        }
    }
}
