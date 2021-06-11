using sdp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Models.Table
{
    public class TableRepository : ITableRepository
    {
        private readonly AppDbContext context;

        public TableRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Table Add(Table table)
        {
            context.Tables.Add(table);
            context.SaveChanges();
            return table;
        }

        public IEnumerable<Table> Alltables()
        {
            return context.Tables;
        }

        public int Delete(int id)
        {
            Table table = context.Tables.Find(id);
            context.Tables.Remove(table);
            context.SaveChanges();
            return 1;
        }

        public Table GetTable(int? id)
        {
            if(id == null)
            {
                return null;
            }
            return context.Tables.Find(id);
        }

        public Table Update(Table table)
        {
            var table1 = context.Tables.Attach(table);
            table1.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return table;
        }

        public IEnumerable<Table> VacantTables(int capacity)
        {
            return context.Tables.Where(c => (c.status == "Vacant" && c.capacity >= capacity));
        }
    }
}
