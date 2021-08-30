using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.EntityFramework.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 60, nullable: false),
                    NumeroCreditos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdCurso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estudiante",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoIdentificacion = table.Column<string>(maxLength: 2, nullable: false),
                    Identificacion = table.Column<string>(maxLength: 15, nullable: false),
                    Nombre1 = table.Column<string>(maxLength: 20, nullable: false),
                    Nombre2 = table.Column<string>(maxLength: 20, nullable: true),
                    Apellido1 = table.Column<string>(maxLength: 20, nullable: false),
                    Apellido2 = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Celular = table.Column<string>(maxLength: 20, nullable: true),
                    Direccion = table.Column<string>(maxLength: 50, nullable: true),
                    Ciudad = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdEstudiante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstudianteCurso",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEstudiante = table.Column<int>(nullable: false),
                    IdCurso = table.Column<int>(nullable: false),
                    NotaFinal = table.Column<decimal>(type: "numeric(3,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstudianteCurso_Curso_IdCurso",
                        column: x => x.IdCurso,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstudianteCurso_Estudiante_IdEstudiante",
                        column: x => x.IdEstudiante,
                        principalTable: "Estudiante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstudianteCurso_IdCurso",
                table: "EstudianteCurso",
                column: "IdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_EstudianteCurso_IdEstudiante",
                table: "EstudianteCurso",
                column: "IdEstudiante");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstudianteCurso");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Estudiante");
        }
    }
}
