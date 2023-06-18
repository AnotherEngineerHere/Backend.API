using Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Backend.Core.Entities;

namespace Backend.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuarios");
                entity.HasKey(u => u.UsuarioId);
                entity.Property(u => u.Nombre).HasMaxLength(100);
                entity.Property(u => u.Apellido).HasMaxLength(100);
                entity.Property(u => u.CorreoElectronico).HasMaxLength(100);
                entity.Property(u => u.FechaNacimiento).HasColumnType("date");
                entity.Property(u => u.Activo);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Clientes");

                // Configuración de la relación con Usuario
                entity.HasOne<Usuario>()
                    .WithOne()
                    .HasForeignKey<Cliente>(c => c.UsuarioId)
                    .IsRequired();
            });
            base.OnModelCreating(modelBuilder);
        }
    }

}
