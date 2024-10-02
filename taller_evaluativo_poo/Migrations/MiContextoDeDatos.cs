using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using taller_evaluativo_poo.AccesoDatos;

#nullable disable

namespace taller_evaluativo_poo.Migration
{
    // Esta clase representa una instantánea del modelo de datos actual para Entity Framework Core
    [DbContext(typeof(Datos))]
    partial class MiContextoDeDatosModelSnapshot : ModelSnapshot
    {
        // Método que construye el modelo de datos
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8") // Especifica la versión del producto
                .HasAnnotation("Relational:MaxIdentifierLength", 128); // Longitud máxima de los identificadores

            // Configuración para usar columnas de identidad en SQL Server
            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            // Configuración de la entidad 'dtosEmpresa'
            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosEmpresa", b =>
                {
                    b.Property<int>("IdEmpresa") // Propiedad de la clave primaria
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEmpresa"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEmpresa"); // Definir la clave primaria

                    b.ToTable("Empresas"); // Mapea la entidad a la tabla 'Empresas'
                });

            // Configuración de la entidad 'dtosFactura'
            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosFactura", b =>
                {
                    b.Property<int>("IdFactura") // Clave primaria de 'dtosFactura'
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFactura"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<long>("Numero")
                        .HasColumnType("bigint");

                    b.Property<int>("IdPersona")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("IdFactura"); // Clave primaria

                    b.HasIndex("IdPersona"); // Crea un índice para la propiedad 'IdPersona'

                    b.ToTable("Facturas"); // Mapea a la tabla 'Facturas'
                });

            // Configuración de la entidad 'dtosPersona'
            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosPersona", b =>
                {
                    b.Property<int>("IdPersona") // Clave primaria
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPersona"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPersona"); // Definir la clave primaria

                    b.ToTable("Personas"); // Mapea a la tabla 'Personas'

                    b.UseTptMappingStrategy(); // Estrategia de mapeo de herencia TPT (Table Per Type)
                });

            // Configuración de la entidad 'dtosProducto'
            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosProducto", b =>
                {
                    b.Property<int>("IdProducto") // Clave primaria
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProducto"));

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

                    b.HasKey("IdProducto"); // Definir la clave primaria

                    b.ToTable("Productos"); // Mapea a la tabla 'Productos'
                });

            // Configuración de la entidad 'dtosProductosPorFactura'
            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosProductosPorFactura", b =>
                {
                    b.Property<int>("IdProductosPorFactura") // Clave primaria
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProductosPorFactura"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("IdFactura")
                        .HasColumnType("int");

                    b.Property<int>("IdProducto")
                        .HasColumnType("int");

                    b.Property<double>("Subtotal")
                        .HasColumnType("float");

                    b.HasKey("IdProductosPorFactura"); // Definir la clave primaria

                    b.HasIndex("IdFactura"); // Crea un índice para 'IdFactura'
                    b.HasIndex("IdProducto"); // Crea un índice para 'IdProducto'

                    b.ToTable("ProductosPorFactura"); // Mapea a la tabla 'ProductosPorFactura'
                });

            // Configuración de la entidad 'dtosCliente'
            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosCliente", b =>
                {
                    b.HasBaseType("taller_evaluativo_poo.AccesoDatos.dtosPersona"); // Hereda de 'dtosPersona'

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<double>("Credito")
                        .HasColumnType("float");

                    b.ToTable("Clientes", (string)null); // Mapea a la tabla 'Clientes'
                });

            // Configuración de la entidad 'dtosVendedor'
            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosVendedor", b =>
                {
                    b.HasBaseType("taller_evaluativo_poo.AccesoDatos.dtosPersona"); // Hereda de 'dtosPersona'

                    b.Property<int>("Carne")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Vendedores", (string)null); // Mapea a la tabla 'Vendedores'
                });

            // Configuración de la relación entre 'dtosFactura' y 'dtosPersona'
            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosFactura", b =>
                {
                    b.HasOne("taller_evaluativo_poo.AccesoDatos.dtosPersona", "Persona")
                        .WithMany("Facturas") // Relación uno a muchos
                        .HasForeignKey("IdPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired(); // Clave foránea obligatoria

                    b.Navigation("Persona"); // Navegación a 'Persona'
                });

            // Configuración de la relación entre 'dtosProductosPorFactura', 'dtosFactura' y 'dtosProducto'
            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosProductosPorFactura", b =>
                {
                    b.HasOne("taller_evaluativo_poo.AccesoDatos.dtosFactura", "Factura")
                        .WithMany("ProductosPorFactura")
                        .HasForeignKey("IdFactura")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired(); // Clave foránea obligatoria

                    b.HasOne("taller_evaluativo_poo.AccesoDatos.dtosProducto", "Producto")
                        .WithMany("ProductosPorFactura")
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired(); // Clave foránea obligatoria

                    b.Navigation("Factura");
                    b.Navigation("Producto");
                });

            // Configuración de la relación entre 'dtosCliente' y 'dtosPersona'
            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosCliente", b =>
                {
                    b.HasOne("taller_evaluativo_poo.AccesoDatos.dtosPersona", null)
                        .WithOne() // Relación uno a uno
                        .HasForeignKey("taller_evaluativo_poo.AccesoDatos.dtosCliente", "IdPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired(); // Clave foránea obligatoria
                });

            // Configuración de la relación entre 'dtosVendedor' y 'dtosPersona'
            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosVendedor", b =>
                {
                    b.HasOne("taller_evaluativo_poo.AccesoDatos.dtosPersona", null)
                        .WithOne() // Relación uno a uno
                        .HasForeignKey("taller_evaluativo_poo.AccesoDatos.dtosVendedor", "IdPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired(); // Clave foránea obligatoria
                });

            // Navegaciones
            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosFactura", b =>
                {
                    b.Navigation("ProductosPorFactura"); // Navegación a productos por factura
                });

            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosPersona", b =>
                {
                    b.Navigation("Facturas"); // Navegación a facturas
                });

            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosProducto", b =>
                {
                    b.Navigation("ProductosPorFactura"); // Navegación a productos por factura
                });
#pragma warning restore 612, 618
        }
    }
}
