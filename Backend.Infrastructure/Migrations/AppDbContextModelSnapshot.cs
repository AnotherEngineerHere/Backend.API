﻿// <auto-generated />
using System;
using Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Backend.Core.Entities.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit")
                        .HasColumnName("is_active");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("last_name");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("email");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("date")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("first_name");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("rol");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("Backend.Core.Entities.Cliente", b =>
                {
                    b.HasBaseType("Backend.Core.Entities.Usuario");

                    b.Property<string>("Dirección")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnName("address");

                    b.Property<string>("Teléfono")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("phone_number");

                    b.ToTable("Clientes", (string)null);
                });

            modelBuilder.Entity("Backend.Core.Entities.Empleado", b =>
                {
                    b.HasBaseType("Backend.Core.Entities.Usuario");

                    b.ToTable("Empleados", (string)null);
                });

            modelBuilder.Entity("Backend.Core.Entities.Cliente", b =>
                {
                    b.HasOne("Backend.Core.Entities.Usuario", null)
                        .WithOne()
                        .HasForeignKey("Backend.Core.Entities.Cliente", "UsuarioId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Core.Entities.Empleado", b =>
                {
                    b.HasOne("Backend.Core.Entities.Usuario", null)
                        .WithOne()
                        .HasForeignKey("Backend.Core.Entities.Empleado", "UsuarioId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
