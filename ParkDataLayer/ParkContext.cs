using Microsoft.EntityFrameworkCore;
using ParkDataLayer.Model;

namespace ParkDataLayer
{
    public class ParkContext : DbContext
    {
        public ParkContext(DbContextOptions<ParkContext> options)
            : base(options)
        {
        }

        public DbSet<HuisEntity> Huizen { get; set; }
        public DbSet<ParkEntity> Parken { get; set; }
        public DbSet<HuurcontractEntity> Huurcontracten { get; set; }
        public DbSet<HuurperiodeEntity> Huurperiodes { get; set; }
        public DbSet<HuurderEntity> Huurders { get; set; }
        public DbSet<ContactgegevensEntity> Contactgegevens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
                        
            modelBuilder.Entity<HuisEntity>()
                .HasOne(h => h.Park)
                .WithMany(p => p.Huizen)
                .HasForeignKey(h => h.ParkId);

            modelBuilder.Entity<HuurcontractEntity>()
                .HasOne(hc => hc.Huis)
                .WithMany(h => h.Huurcontracten)
                .HasForeignKey(hc => hc.HuisId);

            modelBuilder.Entity<HuurcontractEntity>()
                .HasOne(hc => hc.Huurperiode)
                .WithMany()
                .HasForeignKey(hc => hc.HuurperiodeId);

            modelBuilder.Entity<HuurcontractEntity>()
                .HasOne(hc => hc.Huurder)
                .WithMany()
                .HasForeignKey(hc => hc.HuurderId);

            modelBuilder.Entity<HuurderEntity>()
                .HasOne(hd => hd.Contactgegevens)
                .WithOne()
                .HasForeignKey<HuurderEntity>(hd => hd.Id);
        }
    }
}
