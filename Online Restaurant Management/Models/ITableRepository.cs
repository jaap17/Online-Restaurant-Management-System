using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Models.Table
{
    public interface ITableRepository
    {
        Table Add(Table table);

        Table GetTable(int? id);

        IEnumerable<Table> Alltables();

        Table Update(Table table);

        IEnumerable<Table> VacantTables(int capacity);

        int Delete(int id);
    }
}
