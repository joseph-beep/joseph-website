using joseph_website.Models;
using Microsoft.EntityFrameworkCore;

namespace joseph_website.Data
{
    public class WebsiteContext : DbContext
    {
        public WebsiteContext(DbContextOptions<WebsiteContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("persons");
            modelBuilder.Entity<Order>().ToTable("orders");
        }
    }
}
