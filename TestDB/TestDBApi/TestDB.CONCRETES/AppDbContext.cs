using System;
using System.Collections.Generic;
using System.Text;
using TestDB.models;
using Microsoft.EntityFrameworkCore;

namespace TestDB.CONCRETES
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Persona> Persona {  get; set; }
        public DbSet<Empresa> Empresa {  get; set; }
        public DbSet<PersonaEmpresa> PersonaEmpresa {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(30);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Persona>(entity => {

                entity.HasKey(p => p.id);

                entity.Property(p => p.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(p => p.Apellido)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(p => p.Ocupacion)
                    .HasMaxLength(150);

            });

            modelBuilder.Entity<PersonaEmpresa>(entity =>
            {
                entity.HasKey(pe => pe.id);

                entity.HasOne(pe => pe.Persona)
                    .WithMany(p => p.PersonaEmpresas)
                    .HasForeignKey(pe => pe.idPersona)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(pe => pe.Empresa)
                    .WithMany(e => e.PersonaEmpresas)
                    .HasForeignKey(pe => pe.idEmpresa)
                    .OnDelete(DeleteBehavior.Restrict);

            });
         }
    }
}
