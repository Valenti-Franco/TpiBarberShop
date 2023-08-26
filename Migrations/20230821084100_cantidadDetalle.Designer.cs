﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TpiBarberShop.DBContexts;

#nullable disable

namespace TpiBarberShop.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230821084100_cantidadDetalle")]
    partial class cantidadDetalle
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("TpiBarberShop.Entities.ECategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaPublicado")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "es una tijera",
                            FechaPublicado = new DateTime(2023, 8, 21, 5, 41, 0, 7, DateTimeKind.Local).AddTicks(6819),
                            Nombre = "Tijera"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "maquinita good",
                            FechaPublicado = new DateTime(2023, 8, 21, 5, 41, 0, 7, DateTimeKind.Local).AddTicks(6821),
                            Nombre = "Maquinita"
                        });
                });

            modelBuilder.Entity("TpiBarberShop.Entities.ECompras", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaPublicado")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProductoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Compras");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cantidad = 2,
                            Estado = "pendiente",
                            FechaPublicado = new DateTime(2023, 8, 21, 5, 41, 0, 7, DateTimeKind.Local).AddTicks(6804),
                            ProductoId = 1,
                            UsuarioId = 1
                        },
                        new
                        {
                            Id = 2,
                            Cantidad = 4,
                            Estado = "confirmada",
                            FechaPublicado = new DateTime(2023, 8, 21, 5, 41, 0, 7, DateTimeKind.Local).AddTicks(6808),
                            ProductoId = 2,
                            UsuarioId = 2
                        });
                });

            modelBuilder.Entity("TpiBarberShop.Entities.EDetalleCompra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaPublicado")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrdenCompraId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrdenCompraId");

                    b.HasIndex("ProductoId");

                    b.ToTable("DetalleCompra");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cantidad = 3,
                            FechaPublicado = new DateTime(2023, 8, 21, 5, 41, 0, 7, DateTimeKind.Local).AddTicks(6852),
                            OrdenCompraId = 1,
                            ProductoId = 1
                        },
                        new
                        {
                            Id = 2,
                            Cantidad = 1,
                            FechaPublicado = new DateTime(2023, 8, 21, 5, 41, 0, 7, DateTimeKind.Local).AddTicks(6854),
                            OrdenCompraId = 1,
                            ProductoId = 2
                        },
                        new
                        {
                            Id = 3,
                            Cantidad = 5,
                            FechaPublicado = new DateTime(2023, 8, 21, 5, 41, 0, 7, DateTimeKind.Local).AddTicks(6855),
                            OrdenCompraId = 1,
                            ProductoId = 3
                        });
                });

            modelBuilder.Entity("TpiBarberShop.Entities.EOrdenCompra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaPublicado")
                        .HasColumnType("TEXT");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("OrdenCompras");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Estado = "confirmada",
                            FechaPublicado = new DateTime(2023, 8, 21, 5, 41, 0, 7, DateTimeKind.Local).AddTicks(6842),
                            UsuarioId = 1
                        },
                        new
                        {
                            Id = 2,
                            Estado = "pendiente",
                            FechaPublicado = new DateTime(2023, 8, 21, 5, 41, 0, 7, DateTimeKind.Local).AddTicks(6843),
                            UsuarioId = 2
                        });
                });

            modelBuilder.Entity("TpiBarberShop.Entities.EProducto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaPublicado")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("Precio")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Stock")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SubcategoryId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SubcategoryId");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 2,
                            Descripcion = "Navaja",
                            FechaPublicado = new DateTime(2023, 8, 21, 5, 41, 0, 7, DateTimeKind.Local).AddTicks(6616),
                            Nombre = "Navaja",
                            Precio = 5,
                            Stock = 40,
                            SubcategoryId = 1
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Descripcion = "Gel de pelo",
                            FechaPublicado = new DateTime(2023, 8, 21, 5, 41, 0, 7, DateTimeKind.Local).AddTicks(6626),
                            Nombre = "Gel",
                            Precio = 15,
                            Stock = 100,
                            SubcategoryId = 1
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Descripcion = "Maquinita para cortar",
                            FechaPublicado = new DateTime(2023, 8, 21, 5, 41, 0, 7, DateTimeKind.Local).AddTicks(6627),
                            Nombre = "Maquinita",
                            Precio = 80,
                            Stock = 15,
                            SubcategoryId = 1
                        });
                });

            modelBuilder.Entity("TpiBarberShop.Entities.EPuntos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaPublicado")
                        .HasColumnType("TEXT");

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
                            FechaPublicado = new DateTime(2023, 8, 21, 5, 41, 0, 7, DateTimeKind.Local).AddTicks(6765),
                            Nombre = "Pepito",
                            ProductoId = 1,
                            Puntos = 3,
                            UsuarioId = 2
                        },
                        new
                        {
                            Id = 4,
                            FechaPublicado = new DateTime(2023, 8, 21, 5, 41, 0, 7, DateTimeKind.Local).AddTicks(6767),
                            Nombre = "Robert",
                            ProductoId = 1,
                            Puntos = 3,
                            UsuarioId = 7
                        },
                        new
                        {
                            Id = 5,
                            FechaPublicado = new DateTime(2023, 8, 21, 5, 41, 0, 7, DateTimeKind.Local).AddTicks(6768),
                            Nombre = "Jesus",
                            ProductoId = 1,
                            Puntos = 3,
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 2,
                            FechaPublicado = new DateTime(2023, 8, 21, 5, 41, 0, 7, DateTimeKind.Local).AddTicks(6768),
                            Nombre = "Jorge",
                            ProductoId = 2,
                            Puntos = 1,
                            UsuarioId = 3
                        },
                        new
                        {
                            Id = 6,
                            FechaPublicado = new DateTime(2023, 8, 21, 5, 41, 0, 7, DateTimeKind.Local).AddTicks(6773),
                            Nombre = "Jorge123",
                            ProductoId = 2,
                            Puntos = 2,
                            UsuarioId = 4
                        },
                        new
                        {
                            Id = 7,
                            FechaPublicado = new DateTime(2023, 8, 21, 5, 41, 0, 7, DateTimeKind.Local).AddTicks(6774),
                            Nombre = "perro",
                            ProductoId = 2,
                            Puntos = 3,
                            UsuarioId = 5
                        },
                        new
                        {
                            Id = 3,
                            FechaPublicado = new DateTime(2023, 8, 21, 5, 41, 0, 7, DateTimeKind.Local).AddTicks(6775),
                            Nombre = "Juanchon",
                            ProductoId = 3,
                            Puntos = 5,
                            UsuarioId = 6
                        });
                });

            modelBuilder.Entity("TpiBarberShop.Entities.ESubcategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaPublicado")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategory");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 2,
                            FechaPublicado = new DateTime(2023, 8, 21, 5, 41, 0, 7, DateTimeKind.Local).AddTicks(6831),
                            Nombre = "Tijeras"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            FechaPublicado = new DateTime(2023, 8, 21, 5, 41, 0, 7, DateTimeKind.Local).AddTicks(6832),
                            Nombre = "Maquinita"
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

                    b.Property<DateTime>("FechaPublicado")
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
                            FechaPublicado = new DateTime(2023, 8, 21, 5, 41, 0, 7, DateTimeKind.Local).AddTicks(6790),
                            Nombre = "Jose",
                            Password = "123",
                            Role = "Cliente"
                        },
                        new
                        {
                            Id = 2,
                            Email = "Franco@Franco.com",
                            FechaPublicado = new DateTime(2023, 8, 21, 5, 41, 0, 7, DateTimeKind.Local).AddTicks(6792),
                            Nombre = "Franco",
                            Password = "123",
                            Role = "Admin"
                        },
                        new
                        {
                            Id = 3,
                            Email = "Pepito@Pepito.com",
                            FechaPublicado = new DateTime(2023, 8, 21, 5, 41, 0, 7, DateTimeKind.Local).AddTicks(6793),
                            Nombre = "Pepito",
                            Password = "123",
                            Role = "Cliente"
                        });
                });

            modelBuilder.Entity("TpiBarberShop.Entities.ECompras", b =>
                {
                    b.HasOne("TpiBarberShop.Entities.EProducto", "Producto")
                        .WithMany("Compras")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TpiBarberShop.Entities.EUsuarios", "Usuario")
                        .WithMany("Compras")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("TpiBarberShop.Entities.EDetalleCompra", b =>
                {
                    b.HasOne("TpiBarberShop.Entities.EOrdenCompra", "OrdenCompra")
                        .WithMany("DetalleCompra")
                        .HasForeignKey("OrdenCompraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TpiBarberShop.Entities.EProducto", "Producto")
                        .WithMany("DetalleCompra")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrdenCompra");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("TpiBarberShop.Entities.EOrdenCompra", b =>
                {
                    b.HasOne("TpiBarberShop.Entities.EUsuarios", "Usuario")
                        .WithMany("OrdenCompra")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("TpiBarberShop.Entities.EProducto", b =>
                {
                    b.HasOne("TpiBarberShop.Entities.ESubcategory", "Subcategory")
                        .WithMany("Producto")
                        .HasForeignKey("SubcategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subcategory");
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

            modelBuilder.Entity("TpiBarberShop.Entities.ESubcategory", b =>
                {
                    b.HasOne("TpiBarberShop.Entities.ECategory", "Category")
                        .WithMany("SubCategory")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("TpiBarberShop.Entities.ECategory", b =>
                {
                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("TpiBarberShop.Entities.EOrdenCompra", b =>
                {
                    b.Navigation("DetalleCompra");
                });

            modelBuilder.Entity("TpiBarberShop.Entities.EProducto", b =>
                {
                    b.Navigation("Compras");

                    b.Navigation("DetalleCompra");

                    b.Navigation("Puntos");
                });

            modelBuilder.Entity("TpiBarberShop.Entities.ESubcategory", b =>
                {
                    b.Navigation("Producto");
                });

            modelBuilder.Entity("TpiBarberShop.Entities.EUsuarios", b =>
                {
                    b.Navigation("Compras");

                    b.Navigation("OrdenCompra");
                });
#pragma warning restore 612, 618
        }
    }
}
