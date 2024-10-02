using System;  // Importa el espacio de nombres básico de C#
using Microsoft.EntityFrameworkCore;  // Importa el espacio de nombres para EF Core
using Microsoft.EntityFrameworkCore.Infrastructure;  // Importa para trabajar con el contexto de la base de datos
using Microsoft.EntityFrameworkCore.Metadata;  // Importa para definir las metadatas del modelo
using Microsoft.EntityFrameworkCore.Migrations;  // Importa para trabajar con migraciones
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;  // Importa para conversiones de valores
using taller_evaluativo_poo.AccesoDatos;  // Importa el espacio de nombres del proyecto

#nullable disable  // Desactiva las advertencias sobre nullabilidad

namespace taller_evaluativo_poo.Migracion  // Define el espacio de nombres para las migraciones
{
    // Clase que define la migración inicial
    [DbContext(typeof(Datos))]  // Indica el contexto de datos que se utiliza
    [Migration("20241002145311_Diseño2")]  // Indica la versión de la migración
    partial class Diseño2  // Clase parcial para la migración
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)  // Método para construir el modelo
        {
#pragma warning disable 612, 618  // Desactiva advertencias específicas de EF Core

            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")  // Anota la versión del producto
                .HasAnnotation("Relational:MaxIdentifierLength", 128);  // Anota la longitud máxima del identificador

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);  // Configura columnas de identidad

            // Configuración de la entidad 'dtosEmpresa'
            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosEmpresa", b =>
                {
                    b.Property<int>("IdEmpresa")  // Definición de la propiedad 'IdEmpresa'
                        .ValueGeneratedOnAdd()  // Se genera un valor al agregar
                        .HasColumnType("int");  // Especifica el tipo de columna

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEmpresa"));  // Configura como columna de identidad

                    b.Property<string>("Codigo")  // Definición de la propiedad 'Codigo'
                        .IsRequired()  // Es obligatoria
                        .HasColumnType("nvarchar(max)");  // Especifica el tipo de columna

                    b.Property<string>("Nombre")  // Definición de la propiedad 'Nombre'
                        .IsRequired()  // Es obligatoria
                        .HasColumnType("nvarchar(max)");  // Especifica el tipo de columna

                    b.HasKey("IdEmpresa");  // Establece 'EmpresaId' como clave primaria

                    b.ToTable("Empresas");  // Asocia la entidad a la tabla 'Empresas'
                });

            // Configuración de la entidad 'dtosFactura'
            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosFactura", b =>
                {
                    b.Property<int>("IdEmpresa")  // Definición de la propiedad 'IdEmpresa'
                        .ValueGeneratedOnAdd()  // Se genera un valor al agregar
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEmpresa"));  // Configura como columna de identidad

                    b.Property<DateTime>("Fecha")  // Definición de la propiedad 'Fecha'
                        .HasColumnType("datetime2");  // Especifica el tipo de columna

                    b.Property<long>("Numero")  // Definición de la propiedad 'Numero'
                        .HasColumnType("bigint");  // Especifica el tipo de columna

                    b.Property<int>("IdPersona")  // Definición de la propiedad 'IdPersona'
                        .HasColumnType("int");  // Especifica el tipo de columna

                    b.Property<double>("Total")  // Definición de la propiedad 'Total'
                        .HasColumnType("float");  // Especifica el tipo de columna

                    b.HasKey("IdFactura");  // Establece 'IdFactura' como clave primaria

                    b.HasIndex("IdPersona");  // Crea un índice para 'IdPersona'

                    b.ToTable("Facturas");  // Asocia la entidad a la tabla 'Facturas'
                });

            // Configuración de la entidad 'dtosPersona'
            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosPersona", b =>
                {
                    b.Property<int>("IdPersona")  // Definición de la propiedad 'IdPersona'
                        .ValueGeneratedOnAdd()  // Se genera un valor al agregar
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPersona"));  // Configura como columna de identidad

                    b.Property<string>("Codigo")  // Definición de la propiedad 'Codigo'
                        .IsRequired()  // Es obligatoria
                        .HasColumnType("nvarchar(max)");  // Especifica el tipo de columna

                    b.Property<string>("Email")  // Definición de la propiedad 'Email'
                        .IsRequired()  // Es obligatoria
                        .HasColumnType("nvarchar(max)");  // Especifica el tipo de columna

                    b.Property<string>("Nombre")  // Definición de la propiedad 'Nombre'
                        .IsRequired()  // Es obligatoria
                        .HasColumnType("nvarchar(max)");  // Especifica el tipo de columna

                    b.Property<string>("Telefono")  // Definición de la propiedad 'Telefono'
                        .IsRequired()  // Es obligatoria
                        .HasColumnType("nvarchar(max)");  // Especifica el tipo de columna

                    b.HasKey("IdPersona");  // Establece 'IdPersona' como clave primaria

                    b.ToTable("Personas");  // Asocia la entidad a la tabla 'Personas'

                    b.UseTptMappingStrategy();  // Usa la estrategia de mapeo TPT (Table Per Type)
                });

            // Configuración de la entidad 'dtosProducto'
            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosProducto", b =>
                {
                    b.Property<int>("IdProducto")  // Definición de la propiedad 'IdProducto'
                        .ValueGeneratedOnAdd()  // Se genera un valor al agregar
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProducto"));  // Configura como columna de identidad

                    b.Property<string>("Codigo")  // Definición de la propiedad 'Codigo'
                        .IsRequired()  // Es obligatoria
                        .HasColumnType("nvarchar(max)");  // Especifica el tipo de columna

                    b.Property<string>("Nombre")  // Definición de la propiedad 'Nombre'
                        .IsRequired()  // Es obligatoria
                        .HasColumnType("nvarchar(max)");  // Especifica el tipo de columna

                    b.Property<int>("Stock")  // Definición de la propiedad 'Stock'
                        .HasColumnType("int");  // Especifica el tipo de columna

                    b.Property<double>("ValorUnitario")  // Definición de la propiedad 'ValorUnitario'
                        .HasColumnType("float");  // Especifica el tipo de columna

                    b.HasKey("IdProducto");  // Establece 'IdProducto' como clave primaria

                    b.ToTable("Productos");  // Asocia la entidad a la tabla 'Productos'
                });

            // Configuración de la entidad 'dtosProductosPorFactura'
            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosProductosPorFactura", b =>
                {
                    b.Property<int>("IdProductosPorFactura")  // Definición de la propiedad 'IdProductosPorFactura'
                        .ValueGeneratedOnAdd()  // Se genera un valor al agregar
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProductosPorFactura"));  // Configura como columna de identidad

                    b.Property<int>("Cantidad")  // Definición de la propiedad 'Cantidad'
                        .HasColumnType("int");  // Especifica el tipo de columna

                    b.Property<int>("IdFactura")  // Definición de la propiedad 'IdFactura'
                        .HasColumnType("int");  // Especifica el tipo de columna

                    b.Property<int>("IdProducto")  // Definición de la propiedad 'IdProducto'
                        .HasColumnType("int");  // Especifica el tipo de columna

                    b.Property<double>("Subtotal")  // Definición de la propiedad 'Subtotal'
                        .HasColumnType("float");  // Especifica el tipo de columna

                    b.HasKey("IdProductosPorFactura");  // Establece 'IdProductosPorFactura' como clave primaria

                    b.HasIndex("IdFactura");  // Crea un índice para 'IdFactura'

                    b.HasIndex("IdProducto");  // Crea un índice para 'IdProducto'

                    b.ToTable("ProductosPorFactura");  // Asocia la entidad a la tabla 'ProductosPorFactura'
                });

            // Configuración de la entidad 'dtosCliente'
            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosCliente", b =>
                {
                    b.HasBaseType("taller_evaluativo_poo.AccesoDatos.dtosPersona");  // Indica que hereda de 'dtosPersona'

                    b.Property<int>("IdCliente")  // Definición de la propiedad 'IdCliente'
                        .HasColumnType("int");  // Especifica el tipo de columna

                    b.Property<double>("Credito")  // Definición de la propiedad 'Credito'
                        .HasColumnType("float");  // Especifica el tipo de columna

                    b.ToTable("Clientes", (string)null);  // Asocia la entidad a la tabla 'Clientes'
                });

            // Configuración de la entidad 'dtosVendedor'
            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosVendedor", b =>
                {
                    b.HasBaseType("taller_evaluativo_poo.AccesoDatos.dtosPersona");  // Indica que hereda de 'dtosPersona'

                    b.Property<int>("Carne")  // Definición de la propiedad 'Carne'
                        .HasColumnType("int");  // Especifica el tipo de columna

                    b.Property<string>("Direccion")  // Definición de la propiedad 'Direccion'
                        .IsRequired()  // Es obligatoria
                        .HasColumnType("nvarchar(max)");  // Especifica el tipo de columna

                    b.ToTable("Vendedores", (string)null);  // Asocia la entidad a la tabla 'Vendedores'
                });

            // Definición de la relación entre 'dtosFactura' y 'dtosPersona'
            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosFactura", b =>
                {
                    b.HasOne("taller_evaluativo_poo.AccesoDatos.dtosPersona", "Persona")  // Define una relación uno a muchos con 'Persona'
                        .WithMany("Facturas")  // Define la colección de facturas en 'dtosPersona'
                        .HasForeignKey("IdPersona")  // Define la clave foránea
                        .OnDelete(DeleteBehavior.Cascade)  // Comportamiento de eliminación en cascada
                        .IsRequired();  // Es obligatoria

                    b.Navigation("Persona");  // Define la navegación a la entidad 'Persona'
                });

            // Definición de la relación entre 'ProductosPordtosFactura', 'dtosFactura' y 'dtosProducto'
            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.ProductosPordtosFactura", b =>
                {
                    b.HasOne("taller_evaluativo_poo.AccesoDatos.dtosFactura", "Factura")  // Define la relación con 'dtosFactura'
                        .WithMany("ProductosPorFactura")  // Define la colección de productos en 'dtosFactura'
                        .HasForeignKey("IdFactura")  // Define la clave foránea
                        .OnDelete(DeleteBehavior.Cascade)  // Comportamiento de eliminación en cascada
                        .IsRequired();  // Es obligatoria

                    b.HasOne("taller_evaluativo_poo.AccesoDatos.dtosProducto", "Producto")  // Define la relación con 'dtosProducto'
                        .WithMany("ProductosPorFactura")  // Define la colección de productos en 'dtosProducto'
                        .HasForeignKey("IdProducto")  // Define la clave foránea
                        .OnDelete(DeleteBehavior.Cascade)  // Comportamiento de eliminación en cascada
                        .IsRequired();  // Es obligatoria

                    b.Navigation("Factura");  // Define la navegación a la entidad 'Factura'
                    b.Navigation("Producto");  // Define la navegación a la entidad 'Producto'
                });

            // Definición de la relación entre 'dtosCliente' y 'dtosPersona'
            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosCliente", b =>
                {
                    b.HasOne("taller_evaluativo_poo.AccesoDatos.dtosPersona", null)  // Define relación con 'dtosPersona'
                        .WithOne()  // Relación uno a uno
                        .HasForeignKey("taller_evaluativo_poo.AccesoDatos.dtosCliente", "IdPersona")  // Define la clave foránea
                        .OnDelete(DeleteBehavior.Cascade)  // Comportamiento de eliminación en cascada
                        .IsRequired();  // Es obligatoria
                });

            // Definición de la relación entre 'dtosVendedor' y 'dtosPersona'
            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosVendedor", b =>
                {
                    b.HasOne("taller_evaluativo_poo.AccesoDatos.dtosPersona", null)  // Define relación con 'dtosPersona'
                        .WithOne()  // Relación uno a uno
                        .HasForeignKey("taller_evaluativo_poo.AccesoDatos.dtosVendedor", "IdPersona")  // Define la clave foránea
                        .OnDelete(DeleteBehavior.Cascade)  // Comportamiento de eliminación en cascada
                        .IsRequired();  // Es obligatoria
                });

            // Navegaciones para las entidades
            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosFactura", b =>
                {
                    b.Navigation("ProductosPorFactura");  // Navegación a la colección de productos por factura
                });

            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosPersona", b =>
                {
                    b.Navigation("Facturas");  // Navegación a la colección de facturas
                });

            modelBuilder.Entity("taller_evaluativo_poo.AccesoDatos.dtosProducto", b =>
                {
                    b.Navigation("ProductosPorFactura");  // Navegación a la colección de productos por factura
                });
#pragma warning restore 612, 618  // Restaura las advertencias previamente desactivadas
        }
    }
}
