using ExamenAMR.WebSite.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExamenAMR.WebSiite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Carta> Carta { get; set; }
        public DbSet<Tabla> Tabla { get; set; }
        public DbSet<TablaDetalle> TablaDetalle { get; set; }

    }
}