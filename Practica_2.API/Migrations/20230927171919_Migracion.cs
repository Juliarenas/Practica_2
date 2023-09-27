using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practica_2.API.Migrations
{
    /// <inheritdoc />
    public partial class Migracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_Evento = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    fechainicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechafin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tema = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Afiliacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo_participacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Programas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Horarios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sesiones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ponentes = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_nombre_Evento",
                table: "Events",
                column: "nombre_Evento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Participantes_Name",
                table: "Participantes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Programas_ponentes",
                table: "Programas",
                column: "ponentes",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Participantes");

            migrationBuilder.DropTable(
                name: "Programas");
        }
    }
}
