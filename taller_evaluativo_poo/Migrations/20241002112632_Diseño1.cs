using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using taller_evaluativo_poo.AccesoDatos;

#nullable disable

namespace taller_evaluativo_poo.Migrations
{
    // Esta clase es una migración que se aplica al contexto de datos 'MiContextoDeDatos'
    [DbContext(typeof(Datos))]
    [Migration("20241002112632_Diseño1")]
    partial class Diseño1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            // Desactiva las advertencias para versiones obsoletas del API
#pragma warning disable 612, 618
            modelBuilder
                // Establece las anotaciones para la versión del producto y longitud máxima del identificador
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            // Configura la generación de columnas de identidad para SQL Server
            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            // Configuración de la entidad 'dtosEmpresa'
            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosEmpresa", b =>
                {
                    b.Property<int>("IdEmpresa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    // Configura la columna de identidad para IdEmpresa
                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEmpresa"));

                    // Propiedades de la entidad
                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    // Establece la clave primaria
                    b.HasKey("IdEmpresa");

                    // Mapea la entidad a la tabla 'Empresas'
                    b.ToTable("Empresas");
                });

            // Configuración de la entidad 'dtosFactura'
            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosFactura", b =>
                {
                    b.Property<int>("IdFactura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFactura"));

                    // Propiedades de la entidad
                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<long>("Numero")
                        .HasColumnType("bigint");

                    b.Property<int>("IdPersona")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    // Establece la clave primaria
                    b.HasKey("IdFactura");

                    // Establece un índice en IdPersona
                    b.HasIndex("IdPersona");

                    // Mapea la entidad a la tabla 'Facturas'
                    b.ToTable("Facturas");
                });

            // Configuración de la entidad 'dtosPersona'
            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosPersona", b =>
                {
                    b.Property<int>("IdPersona")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPersona"));

                    // Propiedades de la entidad
                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    // Establece la clave primaria
                    b.HasKey("IdPersona");

                    // Mapea la entidad a la tabla 'Personas'
                    b.ToTable("Personas");

                    // Configura la herencia (TPH) para la entidad
                    b.HasDiscriminator().HasValue("dtosPersona");
                    b.UseTphMappingStrategy();
                });

            // Configuración de la entidad 'dtosProducto'
            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosProducto", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProducto"));

                    // Propiedades de la entidad
                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<double>("ValorUnitario")
                        .HasColumnType("float");

                    // Establece la clave primaria
                    b.HasKey("IdProducto");

                    // Mapea la entidad a la tabla 'Productos'
                    b.ToTable("Productos");
                });

            // Configuración de la entidad 'dtosProductosPorFactura'
            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosProductosPorFactura", b =>
                {
                    b.Property<int>("IdProductosPorFactura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProductosPorFactura"));

                    // Propiedades de la entidad
                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("IdFactura")
                        .HasColumnType("int");

                    b.Property<int>("IdProducto")
                        .HasColumnType("int");

                    b.Property<double>("Subtotal")
                        .HasColumnType("float");

                    // Establece la clave primaria
                    b.HasKey("IdProductosPorFactura");

                    // Establece índices en IdFactura e IdProducto
                    b.HasIndex("IdFactura");
                    b.HasIndex("IdProducto");

                    // Mapea la entidad a la tabla 'ProductosPorFactura'
                    b.ToTable("ProductosPorFactura");
                });

            // Configuración de la entidad 'dtosCliente'
            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosCliente", b =>
                {
                    // Hereda de dtosPersona
                    b.HasBaseType("taller_evaluativo_poo.AccesoDatos.dtosPersona");

                    b.Property<double>("Credito")
                        .HasColumnType("float");

                    // Configura el valor del discriminador
                    b.HasDiscriminator().HasValue("dtosCliente");
                });

            // Configuración de la entidad 'dtosVendedor'
            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosVendedor", b =>
                {
                    // Hereda de dtosPersona
                    b.HasBaseType("taller_evaluativo_poo.AccesoDatos.dtosPersona");

                    b.Property<int>("Carne")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    // Configura el valor del discriminador
                    b.HasDiscriminator().HasValue("dtosVendedor");
                });

            // Configuración de la relación entre 'dtosFactura' y 'dtosPersona'
            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosFactura", b =>
                {
                    b.HasOne("taller_evaluativo_poo.AccesoDatos.dtosPersona", "Persona")
                        .WithMany("Facturas")
                        .HasForeignKey("IdPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            // Configuración de la relación entre 'dtosProductosPorFactura', 'dtosFactura' y 'dtosProducto'
            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosProductosPorFactura", b =>
                {
                    b.HasOne("taller_evaluativo_poo.AccesoDatos.dtosFactura", "Factura")
                        .WithMany("ProductosPorFactura")
                        .HasForeignKey("IdFactura")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("taller_evaluativo_poo.AccesoDatos.dtosProducto", "Producto")
                        .WithMany("ProductosPorFactura")
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Factura");
                    b.Navigation("Producto");
                });

            // Navegaciones para las relaciones
            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosFactura", b =>
                {
                    b.Navigation("ProductosPorFactura");
                });

            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosPersona", b =>
                {
                    b.Navigation("Facturas");
                });

            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosProducto", b =>
                {
                    b.Navigation("ProductosPorFactura");
                });
#pragma warning restore 612, 618
        }
    }
}
