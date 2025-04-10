using ApiPrimerExamen.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ApiPrimerExamen.data
{
    public class SeriesContext : DbContext
    {
        public SeriesContext(DbContextOptions<SeriesContext> options) : base(options) { }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Personaje> Personajes { get; set; }
    }

}
