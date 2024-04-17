using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace API_torneo_Mario.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Squadra> Squadras { get; set; }
        public DbSet<Personaggio> Personaggios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Squadra>()
                .HasKey(s => new { s.SquadraID });

            modelBuilder.Entity<Personaggio>()
                .HasKey(p => new { p.PersonaggioID });

            modelBuilder.Entity<Squadra>()
                .HasMany(e => e.elencoPersonaggi)
                .WithOne(s => s.SquadraRifNavigation)
                .HasForeignKey(s => s.SquadraRIF)
                .IsRequired(false);

            modelBuilder.Entity<Personaggio>()
                .HasOne(s => s.SquadraRifNavigation)
                .WithMany(e => e.elencoPersonaggi)
                .HasForeignKey(s => s.SquadraRIF)
                .IsRequired(false);
        }
    }
}
