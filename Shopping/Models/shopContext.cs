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
        public DbSet<ProductMap> ProductMap { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);Database=shop;User Id=sa; Password=!Morning1;MultipleActiveResultSets=true");
            }
        }

    }
}
