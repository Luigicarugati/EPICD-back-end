using Microsoft.EntityFrameworkCore;
using GestioneHotelApp.Models;

namespace GestioneHotelApp.Data
{
    public class GestioneHotelContext : DbContext
    {
        public GestioneHotelContext(DbContextOptions<GestioneHotelContext> options)
            : base(options)
        {
        }

        public DbSet<Camera> Camere { get; set; }
        public DbSet<Cliente> Clienti { get; set; }
        public DbSet<Prenotazione> Prenotazioni { get; set; }
        public DbSet<Servizio> Servizi { get; set; }
        public DbSet<Trattamento> Trattamenti { get; set; }
        public DbSet<PrenotazioneServizio> PrenotazioniServizi { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrenotazioneServizio>()
                .HasKey(ps => ps.Id);

            modelBuilder.Entity<PrenotazioneServizio>()
                .HasOne(ps => ps.Prenotazione)
                .WithMany(p => p.PrenotazioniServizi)
                .HasForeignKey(ps => ps.IdPrenotazione);

            modelBuilder.Entity<PrenotazioneServizio>()
                .HasOne(ps => ps.Servizio)
                .WithMany(s => s.PrenotazioniServizi)
                .HasForeignKey(ps => ps.ServizioId);

            modelBuilder.Entity<Servizio>()
                .HasMany(s => s.PrenotazioniServizi)
                .WithOne(ps => ps.Servizio)
                .HasForeignKey(ps => ps.ServizioId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
 