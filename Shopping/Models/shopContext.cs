using Microsoft.EntityFrameworkCore;

namespace Shopping.Models
{
    public class shopContext:DbContext
    {
        public shopContext() { }
        public shopContext(DbContextOptions options):base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Seller> Sellers { get; set; }
    }
}
