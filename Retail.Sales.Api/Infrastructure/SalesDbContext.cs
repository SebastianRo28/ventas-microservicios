using Microsoft.EntityFrameworkCore;
using Retail.Sales.Api.Domain;

namespace Retail.Sales.Api.Infrastructure
{
    public class SalesDbContext : DbContext
    {
        public SalesDbContext(DbContextOptions<SalesDbContext> options) : base(options) { }

        public DbSet<VentaCab> VentaCab => Set<VentaCab>();
        public DbSet<VentaDet> VentaDet => Set<VentaDet>();
        public DbSet<MovimientoCab> MovimientoCab => Set<MovimientoCab>();
        public DbSet<MovimientoDet> MovimientoDet => Set<MovimientoDet>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VentaCab>().ToTable("VentaCab").HasKey(x => x.Id_VentaCab);
            modelBuilder.Entity<VentaDet>().ToTable("VentaDet").HasKey(x => x.Id_VentaDet);
            modelBuilder.Entity<MovimientoCab>().ToTable("MovimientoCab").HasKey(x => x.Id_MovimientoCab);
            modelBuilder.Entity<MovimientoDet>().ToTable("MovimientoDet").HasKey(x => x.Id_MovimientoDet);

            modelBuilder.Entity<VentaDet>()
                .HasOne(d => d.VentaCab)
                .WithMany(c => c.Detalles)
                .HasForeignKey(d => d.Id_VentaCab);

            modelBuilder.Entity<MovimientoDet>()
                .HasOne(d => d.MovimientoCab)
                .WithMany(c => c.Detalles)
                .HasForeignKey(d => d.Id_movimientocab);

            base.OnModelCreating(modelBuilder);
        }
    }
}
