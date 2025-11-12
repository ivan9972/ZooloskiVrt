using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
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
        public DbSet<Obuka> Obuke { get; set; }
        public DbSet<Licenca> Licence { get; set; }
        public DbSet<Smjena> Smjene { get; set; }
        public DbSet<GodisnjiOdmor> GodisnjiOdmori { get; set; }
        public DbSet<Bolovanje> Bolovanja { get; set; }
        public DbSet<Trosak> Troskovi { get; set; }
        public DbSet<Sanacija> Sanacije { get; set; }
        public DbSet<Posjetitelj> Posjetitelji { get; set; }
    }
}
