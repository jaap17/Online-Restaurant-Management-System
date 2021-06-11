using sdp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Models.TableBooking
{
    public class TableBookingRepository : ITableBookingRepository
    {
        private readonly AppDbContext context;

        public TableBookingRepository(AppDbContext context)
        {
            this.context = context;
        }
        public TableBooking Create(TableBooking tableBooking)
        {
            context.TableBookings.Add(tableBooking);
            context.SaveChanges();
            return tableBooking;
        }

        public int Delete(int id)
        {
            TableBooking tableBooking = context.TableBookings.Find(id);
            if(tableBooking != null)
            {
                context.TableBookings.Remove(tableBooking);
                context.SaveChanges();
            }
           
            return id;
        }

        public TableBooking GetTableBookingbyEmail(string Email)
        {
            return context.TableBookings.FirstOrDefault(ctx => ctx.Email == Email);
        }

        public IEnumerable<TableBooking> getTableBookings()
        {
            return context.TableBookings;
        }
    }
}
