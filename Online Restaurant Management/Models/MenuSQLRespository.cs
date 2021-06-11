using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sdp.Models
{
    public class MenuSQLRespository:IMenuRepository
    {
        private readonly AppDbContext context;

        public MenuSQLRespository(AppDbContext context)
        {
            this.context = context;
        }


        public Menu Add(Menu food)
        {
            context.Menu.Add(food);
            context.SaveChanges();
            return food;
        }

        public Menu Delete(int id)
        {
            Menu food = context.Menu.Find(id);
            if (food != null)
            {
                context.Menu.Remove(food);
                context.SaveChanges();
            }
            return food;
        }

        public IEnumerable<Menu> GetAllFood()
        {
            return context.Menu;
        }

        public IEnumerable<Menu> Foods => context.Menu;


        public Menu GetFood(int Id)
        {
            return context.Menu.Find(Id);
        }

        public Menu Update(Menu ItemChanges)
        {
            var employee = context.Menu.Attach(ItemChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return ItemChanges;
        }
    }
}
