using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Models.TableBooking
{
    public interface ITableBookingRepository
    {
        TableBooking Create(TableBooking tableBooking);

        IEnumerable<TableBooking> getTableBookings();

        TableBooking GetTableBookingbyEmail(string Email);

        int Delete(int id);
    }
}
