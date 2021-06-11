using sdp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sdp2.Models
{
    public class CommentsRepository : ICommentsRepository
    {
        private readonly AppDbContext context;

        public CommentsRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Comments Add(Comments comments)
        {
            context.Comments.Add(comments);
            context.SaveChanges();
            return comments;
        }

        public IEnumerable<Comments> GetComments(int id)
        {
            return context.Comments.Where(e => e.Recipe.RecipesId == id);
        }
    }
}
