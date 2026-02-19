using Microsoft.EntityFrameworkCore;
using Retail.Purchases.Api.Domain;

namespace Retail.Purchases.Api.Infrastructure
{
    public class PurchasesDbContext : DbContext
    {
        public PurchasesDbContext(DbContextOptions<PurchasesDbContext> options) : base(options) { }

        public DbSet<CompraCab> CompraCab => Set<CompraCab>();
        public DbSet<CompraDet> CompraDet => Set<CompraDet>();
        public DbSet<MovimientoCab> MovimientoCab => Set<MovimientoCab>();
        public DbSet<MovimientoDet> MovimientoDet => Set<MovimientoDet>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompraCab>().ToTable("CompraCab").HasKey(x => x.Id_CompraCab);
            modelBuilder.Entity<CompraDet>().ToTable("CompraDet").HasKey(x => x.Id_CompraDet);
            modelBuilder.Entity<MovimientoCab>().ToTable("MovimientoCab").HasKey(x => x.Id_MovimientoCab);
            modelBuilder.Entity<MovimientoDet>().ToTable("MovimientoDet").HasKey(x => x.Id_MovimientoDet);

            modelBuilder.Entity<CompraDet>()
                .HasOne(d => d.CompraCab)
                .WithMany(c => c.Detalles)
                .HasForeignKey(d => d.Id_CompraCab);

            modelBuilder.Entity<MovimientoDet>()
                .HasOne(d => d.MovimientoCab)
                .WithMany(c => c.Detalles)
                .HasForeignKey(d => d.Id_movimientocab);

            base.OnModelCreating(modelBuilder);
        }
    }
}
