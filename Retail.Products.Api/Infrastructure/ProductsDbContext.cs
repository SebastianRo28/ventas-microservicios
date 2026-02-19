using Microsoft.EntityFrameworkCore;
using Retail.Products.Api.Domain;

namespace Retail.Products.Api.Infrastructure
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options) { }

        public DbSet<Producto> Productos => Set<Producto>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().ToTable("Productos").HasKey(x => x.Id_producto);
            base.OnModelCreating(modelBuilder);
        }
    }
}
