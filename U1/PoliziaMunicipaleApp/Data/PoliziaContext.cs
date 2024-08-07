using Microsoft.EntityFrameworkCore;
using PoliziaMunicipaleApp.Models;

namespace PoliziaMunicipaleApp.Data
{
    public class PoliziaContext : DbContext
    {
        public PoliziaContext(DbContextOptions<PoliziaContext> options)
            : base(options)
        {
        }

        public DbSet<Anagrafiche> Anagrafiche { get; set; }
        public DbSet<TipiViolazione> TipiViolazione { get; set; }
        public DbSet<Verbali> Verbali { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurazione delle tabelle
            modelBuilder.Entity<Anagrafiche>().ToTable("Anagrafiche");
            modelBuilder.Entity<TipiViolazione>().ToTable("TipiViolazione");
            modelBuilder.Entity<Verbali>().ToTable("Verbali");

            // Configurazione delle relazioni
            modelBuilder.Entity<Verbali>()
                .HasOne(v => v.Anagrafiche)
                .WithMany(a => a.Verbali)
                .HasForeignKey(v => v.Idanagrafica);

            modelBuilder.Entity<Verbali>()
                .HasOne(v => v.TipiViolazione)
                .WithMany(t => t.Verbali)
                .HasForeignKey(v => v.Idviolazione);
        }
    }
}
