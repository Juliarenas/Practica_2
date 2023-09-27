using Practica_2.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Practica_2.API.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext>options):base(options) { }

        public DbSet<Evento> Events { get; set; }

        public DbSet<Participante> Participantes { get; set; }

        public DbSet<Programa> Programas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Evento>().HasIndex(e => e.nombre_Evento).IsUnique();
            modelBuilder.Entity<Participante>().HasIndex(p => p.Name).IsUnique();
            modelBuilder.Entity<Programa>().HasIndex(p => p.ponentes).IsUnique();

        }




    }
}
