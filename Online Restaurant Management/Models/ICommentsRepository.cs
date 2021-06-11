using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sdp2.Models
{
    public interface ICommentsRepository
    {
        Comments Add(Comments comments);

        IEnumerable<Comments> GetComments(int id);
    }
}
