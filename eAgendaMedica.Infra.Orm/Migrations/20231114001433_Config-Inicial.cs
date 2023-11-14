using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eAgendaMedica.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class ConfigInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBCirurgia",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    horaInicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    horaTermino = table.Column<TimeSpan>(type: "time", nullable: false),
                    MedicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCirurgia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBConsulta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    horaInicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    horaTermino = table.Column<TimeSpan>(type: "time", nullable: false),
                    MedicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBConsulta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBMedico",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CRM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disponivel = table.Column<bool>(type: "bit", nullable: false),
                    CirurgiaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ConsultaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBMedico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBMedico_TBCirurgia_CirurgiaId",
                        column: x => x.CirurgiaId,
                        principalTable: "TBCirurgia",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBMedico_TBConsulta_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "TBConsulta",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBCirurgia_MedicoId",
                table: "TBCirurgia",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBConsulta_MedicoId",
                table: "TBConsulta",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBMedico_CirurgiaId",
                table: "TBMedico",
                column: "CirurgiaId");

            migrationBuilder.CreateIndex(
                name: "IX_TBMedico_ConsultaId",
                table: "TBMedico",
                column: "ConsultaId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBMedico_TBCirugia",
                table: "TBCirurgia",
                column: "MedicoId",
                principalTable: "TBMedico",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBMedico_TBConsulta",
                table: "TBConsulta",
                column: "MedicoId",
                principalTable: "TBMedico",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBMedico_TBCirugia",
                table: "TBCirurgia");

            migrationBuilder.DropForeignKey(
                name: "FK_TBMedico_TBConsulta",
                table: "TBConsulta");

            migrationBuilder.DropTable(
                name: "TBMedico");

            migrationBuilder.DropTable(
                name: "TBCirurgia");

            migrationBuilder.DropTable(
                name: "TBConsulta");
        }
    }
}
