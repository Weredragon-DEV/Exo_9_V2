using Microsoft.EntityFrameworkCore;
using Exo_9_V2.Models;

namespace Exo_9_V2.Data
{
    public class _AppDBContext : DbContext
    {
        public _AppDBContext(DbContextOptions<_AppDBContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Voiture> Voitures { get; set; }
    }
}