using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Models;

namespace Database.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Serie> Series { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Productora> Productoras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API
            #region Tables
            modelBuilder.Entity<Serie>().ToTable("Series");
            modelBuilder.Entity<Genero>().ToTable("Generos");
            modelBuilder.Entity<Productora>().ToTable("Productoras");
            #endregion

            #region "Primary Keys"
            modelBuilder.Entity<Serie>().HasKey(serie => serie.IdSerie);
            modelBuilder.Entity<Genero>().HasKey(genero => genero.IdGenero);
            modelBuilder.Entity<Productora>().HasKey(productora => productora.IdProductora);
            #endregion

            #region relationships
            #region Genero/Serie
            modelBuilder.Entity<Genero>()
                .HasMany<Serie>(genero => genero.Series)
                .WithOne(serie => serie.Genero)
                .HasForeignKey(serie => serie.IdGenero)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Productora/Serie
            modelBuilder.Entity<Productora>()
                .HasMany<Serie>(productora => productora.Series)
                .WithOne(serie => serie.Productora)
                .HasForeignKey(serie => serie.IdProductora)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
            #endregion

            #region "Propertys configurations"
            #region Serie
            modelBuilder.Entity<Serie>().Property(serie => serie.Nombre)
                .IsRequired()
                .HasMaxLength(150);
            modelBuilder.Entity<Serie>().Property(serie => serie.Portada)
                .IsRequired();
            modelBuilder.Entity<Serie>().Property(serie => serie.Trailer)
                .IsRequired();
            modelBuilder.Entity<Serie>().Property(serie => serie.IdGenero)
                .IsRequired();
            modelBuilder.Entity<Serie>().Property(serie => serie.IdProductora)
                .IsRequired();
            #endregion

            #region Genero
            modelBuilder.Entity<Genero>().Property(genero => genero.Nombre)
                .IsRequired();
            #endregion

            #region Productora
            modelBuilder.Entity<Productora>().Property(productora => productora.Nombre)
                .IsRequired();
            #endregion
            #endregion
        }
    }
}
