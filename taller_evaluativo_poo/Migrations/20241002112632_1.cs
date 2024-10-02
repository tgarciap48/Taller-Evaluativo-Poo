using System;  // Importa el espacio de nombres básico de C#
using Microsoft.EntityFrameworkCore.Migrations;  // Importa el espacio de nombres para migraciones de EF Core

#nullable disable  // Desactiva las advertencias sobre nullabilidad

namespace taller_evaluativo_poo.Migration  // Define el espacio de nombres para esta migración
{
    // Clase que representa la migración
    public partial class Diseño1 : Migrations
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)  // Método que se ejecuta al aplicar la migración
        {
            // Crea la tabla 'Empresas'
            migrationBuilder.CreateTable(
                name: "Empresas",  // Nombre de la tabla
                columns: table => new  // Define las columnas de la tabla
                {
                    IdEmpresa = table.Column<int>(type: "int", nullable: false)  // Columna 'IdEmpresa' de tipo int, no nula
                        .Annotation("SqlServer:Identity", "1, 1"),  // Configura como columna de identidad
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),  // Columna 'Codigo', tipo nvarchar, no nula
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)  // Columna 'Nombre', tipo nvarchar, no nula
                },
                constraints: table =>  // Establece las restricciones de la tabla
                {
                    table.PrimaryKey("PK_Empresas", x => x.IdEmpresa);  // Establece 'IdEmpresa' como clave primaria
                });

            // Crea la tabla 'Personas'
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    IdPersona = table.Column<int>(type: "int", nullable: false)  // Columna 'IdPersona' de tipo int, no nula
                        .Annotation("SqlServer:Identity", "1, 1"),  // Configura como columna de identidad
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),  // Columna 'Codigo', tipo nvarchar, no nula
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),  // Columna 'Email', tipo nvarchar, no nula
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),  // Columna 'Nombre', tipo nvarchar, no nula
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),  // Columna 'Telefono', tipo nvarchar, no nula
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),  // Columna para herencia
                    Credito = table.Column<double>(type: "float", nullable: true),  // Columna 'Credito', tipo float, nullable
                    Carne = table.Column<int>(type: "int", nullable: true),  // Columna 'Carne', tipo int, nullable
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true)  // Columna 'Direccion', tipo nvarchar, nullable
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.IdPersona);  // Establece 'IdPersona' como clave primaria
                });

            // Crea la tabla 'Productos'
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)  // Columna 'IdProducto' de tipo int, no nula
                        .Annotation("SqlServer:Identity", "1, 1"),  // Configura como columna de identidad
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),  // Columna 'Codigo', tipo nvarchar, no nula
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),  // Columna 'Nombre', tipo nvarchar, no nula
                    Stock = table.Column<int>(type: "int", nullable: false),  // Columna 'Stock', tipo int, no nula
                    ValorUnitario = table.Column<double>(type: "float", nullable: false)  // Columna 'ValorUnitario', tipo float, no nula
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IdProducto);  // Establece 'IdProducto' como clave primaria
                });

            // Crea la tabla 'Facturas'
            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    IdFactura = table.Column<int>(type: "int", nullable: false)  // Columna 'IdFactura' de tipo int, no nula
                        .Annotation("SqlServer:Identity", "1, 1"),  // Configura como columna de identidad
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),  // Columna 'Fecha', tipo DateTime, no nula
                    Numero = table.Column<long>(type: "bigint", nullable: false),  // Columna 'Numero', tipo long, no nula
                    Total = table.Column<double>(type: "float", nullable: false),  // Columna 'Total', tipo float, no nula
                    IdPersona = table.Column<int>(type: "int", nullable: false)  // Columna 'IdPersona', tipo int, no nula
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.IdFactura);  // Establece 'IdFactura' como clave primaria
                    table.ForeignKey(  // Establece una clave foránea con la tabla 'Personas'
                        name: "FK_Facturas_Personas_IdPersona",
                        column: x => x.IdPersona,  // Columna de la clave foránea
                        principalTable: "Personas",  // Tabla principal
                        principalColumn: "IdPersona",  // Columna principal
                        onDelete: ReferentialAction.Cascade);  // Acción en caso de eliminación
                });

            // Crea la tabla 'ProductosPorFactura'
            migrationBuilder.CreateTable(
                name: "ProductosPorFactura",
                columns: table => new
                {
                    IdProductosPorFactura = table.Column<int>(type: "int", nullable: false)  // Columna 'IdProductosPorFactura' de tipo int, no nula
                        .Annotation("SqlServer:Identity", "1, 1"),  // Configura como columna de identidad
                    Cantidad = table.Column<int>(type: "int", nullable: false),  // Columna 'Cantidad', tipo int, no nula
                    Subtotal = table.Column<double>(type: "float", nullable: false),  // Columna 'Subtotal', tipo float, no nula
                    IdFactura = table.Column<int>(type: "int", nullable: false),  // Columna 'IdFactura', tipo int, no nula
                    IdProducto = table.Column<int>(type: "int", nullable: false)  // Columna 'IdProducto', tipo int, no nula
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosPorFactura", x => x.IdProductosPorFactura);  // Establece 'IdProductosPorFactura' como clave primaria
                    table.ForeignKey(  // Establece una clave foránea con la tabla 'Facturas'
                        name: "FK_ProductosPorFactura_Facturas_IdFactura",
                        column: x => x.IdFactura,  // Columna de la clave foránea
                        principalTable: "Facturas",  // Tabla principal
                        principalColumn: "IdFactura",  // Columna principal
                        onDelete: ReferentialAction.Cascade);  // Acción en caso de eliminación
                    table.ForeignKey(  // Establece una clave foránea con la tabla 'Productos'
                        name: "FK_ProductosPorFactura_Productos_IdProducto",
                        column: x => x.IdProducto,  // Columna de la clave foránea
                        principalTable: "Productos",  // Tabla principal
                        principalColumn: "IdProducto",  // Columna principal
                        onDelete: ReferentialAction.Cascade);  // Acción en caso de eliminación
                });

            // Crea índices para mejorar la consulta
            migrationBuilder.CreateIndex(
                name: "IX_Facturas_IdPersona",  // Nombre del índice
                table: "Facturas",  // Tabla donde se aplica el índice
                column: "IdPersona");  // Columna indexada

            migrationBuilder.CreateIndex(
                name: "IX_ProductosPorFactura_IdFactura",  // Nombre del índice
                table: "ProductosPorFactura",  // Tabla donde se aplica el índice
                column: "IdFactura");  // Columna indexada

            migrationBuilder.CreateIndex(
                name: "IX_ProductosPorFactura_IdProducto",  // Nombre del índice
                table: "ProductosPorFactura",  // Tabla donde se aplica el índice
                column: "IdProducto");  // Columna indexada
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)  // Método que se ejecuta al revertir la migración
        {
            // Elimina las tablas en el orden inverso a la creación
            migrationBuilder.DropTable(name: "Empresas");
            migrationBuilder.DropTable(name: "ProductosPorFactura");
            migrationBuilder.DropTable(name: "Facturas");
            migrationBuilder.DropTable(name: "Productos");
            migrationBuilder.DropTable(name: "Personas");
        }
    }
}