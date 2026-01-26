using Microsoft.EntityFrameworkCore;
using ZooloskiVrt.Models;

namespace ZooloskiVrt.Data
{
    public class ZooloskiVrtContext : DbContext
    {
        public ZooloskiVrtContext(DbContextOptions<ZooloskiVrtContext> options)
            : base(options) { }

        public DbSet<Zivotinja> Zivotinje { get; set; }
        public DbSet<Nastamba> Nastambe { get; set; }
        public DbSet<Radnik> Radnici { get; set; }
        public DbSet<Obaveza> Obaveze { get; set; }
        public DbSet<Incident> Incidenti { get; set; }

        public DbSet<IncidentNastamba> IncidentNastambe { get; set; }
        public DbSet<IncidentZivotinja> IncidentZivotinje { get; set; }

        public DbSet<Obuka> Obuke { get; set; }
        public DbSet<Licenca> Licence { get; set; }
        public DbSet<Smjena> Smjene { get; set; }
        public DbSet<GodisnjiOdmor> GodisnjiOdmori { get; set; }
        public DbSet<Bolovanje> Bolovanja { get; set; }
        public DbSet<Trosak> Troskovi { get; set; }
        public DbSet<Sanacija> Sanacije { get; set; }
        public DbSet<Posjetitelj> Posjetitelji { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
            modelBuilder.Entity<Obaveza>()
                .HasOne(o => o.Radnik)
                .WithMany(r => r.Obaveze)
                .HasForeignKey(o => o.RadnikID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Obaveza>()
                .HasOne(o => o.Nastamba)
                .WithMany(n => n.Obaveze)
                .HasForeignKey(o => o.NastambaID)
                .OnDelete(DeleteBehavior.Restrict);

            
            modelBuilder.Entity<Zivotinja>()
                .HasOne(z => z.Nastamba)
                .WithMany(n => n.Zivotinje)
                .HasForeignKey(z => z.NastambaID)
                .OnDelete(DeleteBehavior.Restrict);

            
            modelBuilder.Entity<IncidentNastamba>()
                .HasOne(x => x.Incident)
                .WithMany(i => i.IncidentiNastambe)
                .HasForeignKey(x => x.IncidentID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<IncidentNastamba>()
                .HasOne(x => x.Nastamba)
                .WithMany(n => n.IncidentiNastambe)
                .HasForeignKey(x => x.NastambaID)
                .OnDelete(DeleteBehavior.Restrict);

            
            modelBuilder.Entity<IncidentZivotinja>()
                .HasOne(x => x.Incident)
                .WithMany(i => i.IncidentiZivotinje)
                .HasForeignKey(x => x.IncidentID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<IncidentZivotinja>()
                .HasOne(x => x.Zivotinja)
                .WithMany(z => z.IncidentiZivotinje)
                .HasForeignKey(x => x.ZivotinjaID)
                .OnDelete(DeleteBehavior.Restrict);

           
            modelBuilder.Entity<Sanacija>()
                .HasOne(s => s.Incident)
                .WithMany(i => i.Sanacije)
                .HasForeignKey(s => s.IncidentID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Sanacija>()
                .HasOne(s => s.Radnik)
                .WithMany(r => r.Sanacije)
                .HasForeignKey(s => s.RadnikID)
                .OnDelete(DeleteBehavior.Restrict);

          
            modelBuilder.Entity<Posjetitelj>()
                .HasOne(p => p.Vodic)
                .WithMany()
                .HasForeignKey(p => p.VodicID)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
