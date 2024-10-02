using Microsoft.EntityFrameworkCore.Migrations; // Importa la funcionalidad para las migraciones de EF Core.

#nullable disable // Desactiva la referencia a la compatibilidad con tipos anulables.

namespace taller_evaluativo_poo.Migration // Define el espacio de nombres para la migración.
{
    /// <inheritdoc />
    public partial class Diseño2 : Migration // Declara una clase de migración que hereda de la clase base Migration.
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) // Método que se ejecuta al aplicar la migración.
        {
            // Elimina las columnas 'Carne', 'Credito', 'Direccion', y 'Discriminator' de la tabla 'Personas'.
            migrationBuilder.DropColumn(name: "Carne", table: "Personas");
            migrationBuilder.DropColumn(name: "Credito", table: "Personas");
            migrationBuilder.DropColumn(name: "Direccion", table: "Personas");
            migrationBuilder.DropColumn(name: "Discriminator", table: "Personas");

            // Crea la tabla 'Clientes' con las siguientes columnas.
            migrationBuilder.CreateTable(
                name: "Clientes", // Nombre de la nueva tabla.
                columns: table => new // Define las columnas de la tabla.
                {
                    PersonaId = table.Column<int>(type: "int", nullable: false), // Clave primaria y FK hacia 'Personas'.
                    ClienteId = table.Column<int>(type: "int", nullable: false), // Identificador único para clientes.
                    Credito = table.Column<double>(type: "float", nullable: false) // Campo para crédito del cliente.
                },
                constraints: table => // Establece las restricciones de la tabla.
                {
                    table.PrimaryKey("PK_Clientes", x => x.PersonaId); // Define la clave primaria.
                    table.ForeignKey( // Establece la relación con la tabla 'Personas'.
                        name: "FK_Clientes_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "PersonaId",
                        onDelete: ReferentialAction.Cascade); // Borrado en cascada.
                });

            // Crea la tabla 'Vendedores' de forma similar.
            migrationBuilder.CreateTable(
                name: "Vendedores",
                columns: table => new
                {
                    PersonaId = table.Column<int>(type: "int", nullable: false), // Clave primaria y FK hacia 'Personas'.
                    Carne = table.Column<int>(type: "int", nullable: false), // Identificador único para vendedores.
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false) // Campo para dirección del vendedor.
                },
                constraints: table => // Establece las restricciones de la tabla.
                {
                    table.PrimaryKey("PK_Vendedores", x => x.PersonaId); // Define la clave primaria.
                    table.ForeignKey( // Establece la relación con la tabla 'Personas'.
                        name: "FK_Vendedores_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "PersonaId",
                        onDelete: ReferentialAction.Cascade); // Borrado en cascada.
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) // Método que se ejecuta al revertir la migración.
        {
            // Elimina las tablas 'Clientes' y 'Vendedores'.
            migrationBuilder.DropTable(name: "Clientes");
            migrationBuilder.DropTable(name: "Vendedores");

            // Restaura las columnas eliminadas en la tabla 'Personas'.
            migrationBuilder.AddColumn<int>(
                name: "Carne",
                table: "Personas",
                type: "int",
                nullable: true); // Campo 'Carne' restaurado.

            migrationBuilder.AddColumn<double>(
                name: "Credito",
                table: "Personas",
                type: "float",
                nullable: true); // Campo 'Credito' restaurado.

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true); // Campo 'Direccion' restaurado.

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Personas",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: ""); // Campo 'Discriminator' restaurado.
        }
    }
}
