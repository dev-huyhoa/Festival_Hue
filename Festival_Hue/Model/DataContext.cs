using Festival_Hue.Models;
using Microsoft.EntityFrameworkCore;

namespace Festival_Hue.Model
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<RoleModel> RoleModels { get; set; }
        public DbSet<EventModel> EventModels { get; set; }
        public DbSet<TicketModel> TicketModels { get; set; }
        public DbSet<CustomerModel> CustomerModels { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }

    }
}
