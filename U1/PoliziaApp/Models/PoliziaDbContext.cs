using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PoliziaApp.Models
{
    public class PoliziaDbContext : DbContext
    {
        public PoliziaDbContext(DbContextOptions<PoliziaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Anagrafica> Anagrafiche { get; set; }
        public DbSet<TipoViolazione> TipiViolazioni { get; set; }
        public DbSet<Verbale> Verbali { get; set; }
    }
}
