using Microsoft.EntityFrameworkCore;
using RentApp.Entities.Tables;

namespace RentApp.DataAccessLayer
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Roles>Roles { get; set; }
    }
}
