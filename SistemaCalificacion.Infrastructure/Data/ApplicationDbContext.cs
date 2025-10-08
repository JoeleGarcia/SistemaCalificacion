using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaCalificacion.Domain.Entities;


namespace SistemaCalificacion.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<Materia> Materia { get; set; }
        public DbSet<Calificaciones> Calificaciones { get; set; }


        //https://learn.microsoft.com/en-us/ef/core/modeling/indexes?tabs=data-annotations
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(entity => {
                entity.HasIndex(e => e.Email).IsUnique();
            });

            builder.Entity<User>(entity => {
                entity.HasIndex(e => e.Username).IsUnique();
            });

            builder.Entity<Estudiante>(entity =>
            {
                entity.HasIndex(e => e.Cedula).IsUnique();
            });

            builder.Entity<Estudiante>(entity => {
                entity.HasIndex(e => e.Username).IsUnique();
            });

            builder.Entity<Materia>(entity => {
                entity.HasIndex(e => e.Nombre).IsUnique();
            });


            builder.Entity<Calificaciones>()
                .HasOne(c => c.Estudiante)
                .WithMany(e => e.Calificaciones)
                .HasForeignKey(c => c.EstudianteId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Calificaciones>()
                .HasOne(c => c.Materia)
                .WithMany(m => m.Calificaciones)
                .HasForeignKey(c => c.MateriaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Calificaciones>(entity =>
            {
                entity.ToTable("Calificaciones");

                entity.Property(c => c.Calificacion1).HasColumnType("decimal(5,2)").IsRequired(false);
                entity.Property(c => c.Calificacion2).HasColumnType("decimal(5,2)").IsRequired(false);
                entity.Property(c => c.Calificacion3).HasColumnType("decimal(5,2)").IsRequired(false);
                entity.Property(c => c.Calificacion4).HasColumnType("decimal(5,2)").IsRequired(false);
                entity.Property(c => c.Total).HasColumnType("decimal(5,2)").IsRequired(false);
                entity.Property(c => c.Examen).HasColumnType("decimal(5,2)").IsRequired(false);
            });

        }

    }

}
