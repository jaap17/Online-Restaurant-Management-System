using sdp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sdp2.Models
{
    public class ReplyRepository : IReplyRepository
    {
        private readonly AppDbContext context;

        public ReplyRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Reply Add(Reply reply)
        {
            context.Replies.Add(reply);
            context.SaveChanges();
            return reply;
        }

        public Reply GetReply(string Email,int id)
        {
            IEnumerable<Reply> fetch = context.Replies.Where(e => e.FeedbackEmail == Email && e.FeedbackId == id);
            if(fetch.Count() == 0)
            {
                return null;
            }
            return fetch.First();
        }
    }
}
