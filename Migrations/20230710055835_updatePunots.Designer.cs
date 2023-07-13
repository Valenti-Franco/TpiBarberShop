﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TpiBarberShop.DBContexts;

#nullable disable

namespace TpiBarberShop.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230710055835_updatePunots")]
    partial class updatePunots
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("TpiBarberShop.Entities.EProducto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Navaja Filosa",
                            Nombre = "Navaja"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Gel de pelo",
                            Nombre = "Gel"
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "Maquinita para cortar",
                            Nombre = "Maquinita"
                        });
                });

            modelBuilder.Entity("TpiBarberShop.Entities.EPuntos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Puntos")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProductoId");

                    b.ToTable("Puntos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Pepito",
                            ProductoId = 1,
                            Puntos = 3,
                            UsuarioId = 2
                        },
                        new
                        {
                            Id = 4,
                            Nombre = "Robert",
                            ProductoId = 1,
                            Puntos = 3,
                            UsuarioId = 7
                        },
                        new
                        {
                            Id = 5,
                            Nombre = "Jesus",
                            ProductoId = 1,
                            Puntos = 3,
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Jorge",
                            ProductoId = 2,
                            Puntos = 1,
                            UsuarioId = 3
                        },
                        new
                        {
                            Id = 6,
                            Nombre = "Jorge123",
                            ProductoId = 2,
                            Puntos = 2,
                            UsuarioId = 4
                        },
                        new
                        {
                            Id = 7,
                            Nombre = "perro",
                            ProductoId = 2,
                            Puntos = 3,
                            UsuarioId = 5
                        },
                        new
                        {
                            Id = 3,
                            Nombre = "Juanchon",
                            ProductoId = 3,
                            Puntos = 5,
                            UsuarioId = 6
                        });
                });

            modelBuilder.Entity("TpiBarberShop.Entities.EUsuarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "jose@jose.com",
                            Nombre = "Jose",
                            Password = "123",
                            Role = "Cliente"
                        },
                        new
                        {
                            Id = 2,
                            Email = "Franco@Franco.com",
                            Nombre = "Franco",
                            Password = "123",
                            Role = "Admin"
                        },
                        new
                        {
                            Id = 3,
                            Email = "Pepito@Pepito.com",
                            Nombre = "Pepito",
                            Password = "123",
                            Role = "Cliente"
                        });
                });

            modelBuilder.Entity("TpiBarberShop.Entities.EPuntos", b =>
                {
                    b.HasOne("TpiBarberShop.Entities.EProducto", "Producto")
                        .WithMany("Puntos")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("TpiBarberShop.Entities.EProducto", b =>
                {
                    b.Navigation("Puntos");
                });
#pragma warning restore 612, 618
        }
    }
}
