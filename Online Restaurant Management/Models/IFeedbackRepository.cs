using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sdp2.Models
{
    public interface IFeedbackRepository
    {
        Feedback add(Feedback feedback);

        IEnumerable<Feedback> GetFeedbacks();

        Feedback Update(Feedback feedback);
    }
}
