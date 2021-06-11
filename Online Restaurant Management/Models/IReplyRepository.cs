using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sdp2.Models
{
    public interface IReplyRepository
    {
        Reply Add(Reply reply);

        Reply GetReply(string Email,int id);
    }
}
