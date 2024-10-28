using Microsoft.EntityFrameworkCore;
using ServicesUsingEF.Models;

namespace ServicesUsingEF.Entity
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options): base(options){ }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(x => x.Id);
            modelBuilder.Entity<Customer>().HasData(
                new Customer{
                    Id = 1,
                    Name = "Suresh Kumar",
                    Gender = "Male",
                    City = "Hyd"

            });
        }
    }
}
