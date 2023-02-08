using BCityData.Models;
using Microsoft.EntityFrameworkCore;

namespace BCityData
{
    public class BCityDBContext : DbContext
    {
        public BCityDBContext(DbContextOptions<BCityDBContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactAssignment> ContactAssignments { get; set; }
    }
}
