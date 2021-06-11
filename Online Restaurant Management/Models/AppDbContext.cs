using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Models.Recipes;
using RestaurantManagementSystem.Models.Table;
using RestaurantManagementSystem.Models.TableBooking;
using sdp2.Models;
using System.Linq;

namespace sdp.Models
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Reply> Replies { get; set; }

        public DbSet<Feedback> feedbacks { get; set; }

        public DbSet<Menu> Menu { get; set; }
        
       public DbSet<ShoppingcartItem> ShoppingCartItems { get; set; } 
        public DbSet<Order> Orderrs { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Recipes> Recipes { get; set; }

        public DbSet<Table> Tables { get; set; }

        public DbSet<TableBooking> TableBookings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            ////modelBuilder.Entity<Order>().Property(e => e.OrderId).ValueGeneratedNever();
            //modelBuilder.Entity<Order>().Property(e => e.Key).ValueGeneratedNever();
        }
        public DbSet<sdp2.Models.Reply> Reply { get; set; }
        public DbSet<sdp2.Models.Comments> Comments { get; set; }
    }
}
