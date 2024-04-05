using JP.Models;
using Microsoft.EntityFrameworkCore;

namespace JP.Data
{
    public class dbcontext:DbContext
    {
        public dbcontext(DbContextOptions<dbcontext> s):base(s) 
        {
            
        }
        public DbSet<UserModel> Registers { get; set; }
        public DbSet<ContactModel> Contacts { get; set; }
        public DbSet<BookingModel> Booking { get; set; }

        public DbSet<AdminEvent> AdminEvent { get; set; }

    }
}
