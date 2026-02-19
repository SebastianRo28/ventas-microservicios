using Microsoft.EntityFrameworkCore;
using Retail.Movements.Api.Domain;

namespace Retail.Movements.Api.Infrastructure
{
    public class MovementsDbContext : DbContext
    {
        public MovementsDbContext(DbContextOptions<MovementsDbContext> options) : base(options) { }

        public DbSet<MovimientoCab> MovimientoCab => Set<MovimientoCab>();
        public DbSet<MovimientoDet> MovimientoDet => Set<MovimientoDet>();
        public DbSet<Producto> Productos => Set<Producto>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovimientoCab>().ToTable("MovimientoCab").HasKey(x => x.Id_MovimientoCab);
            modelBuilder.Entity<MovimientoDet>().ToTable("MovimientoDet").HasKey(x => x.Id_MovimientoDet);
            modelBuilder.Entity<Producto>().ToTable("Productos").HasKey(x => x.Id_producto);

            modelBuilder.Entity<MovimientoDet>()
                .HasOne(d => d.MovimientoCab)
                .WithMany(c => c.Detalles)
                .HasForeignKey(d => d.Id_movimientocab);

            base.OnModelCreating(modelBuilder);
        }
    }
}
