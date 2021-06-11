using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sdp.Models
{
   public interface IMenuRepository
    {
        Menu GetFood(int Id);
        IEnumerable<Menu> GetAllFood();
       IEnumerable<Menu> Foods { get; }

        Menu Add(Menu food);

        Menu Update(Menu ItemChanges);
        Menu Delete(int id);
    }
}
