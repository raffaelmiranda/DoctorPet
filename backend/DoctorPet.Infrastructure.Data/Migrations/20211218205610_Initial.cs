using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorPet.Infrastructure.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(max)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ClienteId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoAnimal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(max)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TipoAnimalId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veterinario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(max)", nullable: false),
                    Geriatria = table.Column<bool>(type: "bit", nullable: false),
                    DataContratacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("VeterinarioId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(max)", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    TipoAnimalId = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("AnimalId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animal_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animal_TipoAnimal_TipoAnimalId",
                        column: x => x.TipoAnimalId,
                        principalTable: "TipoAnimal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agendamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataConsulta = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    VeterinarioId = table.Column<int>(type: "int", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("AgendamentoId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendamento_Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendamento_Veterinario_VeterinarioId",
                        column: x => x.VeterinarioId,
                        principalTable: "Veterinario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atendimento",
                columns: table => new
                {
                    VeterinarioId = table.Column<int>(type: "int", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    Diagnostico = table.Column<string>(type: "varchar(max)", nullable: false),
                    DataAtendimento = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimento", x => new { x.VeterinarioId, x.AnimalId });
                    table.ForeignKey(
                        name: "FK_Atendimento_Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Atendimento_Veterinario_VeterinarioId",
                        column: x => x.VeterinarioId,
                        principalTable: "Veterinario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TipoAnimal",
                columns: new[] { "Id", "DataCadastro", "Nome" },
                values: new object[] { 1, new DateTime(2021, 12, 18, 17, 56, 10, 192, DateTimeKind.Local).AddTicks(7719), "Cães" });

            migrationBuilder.InsertData(
                table: "TipoAnimal",
                columns: new[] { "Id", "DataCadastro", "Nome" },
                values: new object[] { 2, new DateTime(2021, 12, 18, 17, 56, 10, 194, DateTimeKind.Local).AddTicks(6452), "Gatos" });

            migrationBuilder.InsertData(
                table: "TipoAnimal",
                columns: new[] { "Id", "DataCadastro", "Nome" },
                values: new object[] { 3, new DateTime(2021, 12, 18, 17, 56, 10, 194, DateTimeKind.Local).AddTicks(6569), "Hamsters" });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_AnimalId",
                table: "Agendamento",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_VeterinarioId",
                table: "Agendamento",
                column: "VeterinarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_ClienteId",
                table: "Animal",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_TipoAnimalId",
                table: "Animal",
                column: "TipoAnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_AnimalId",
                table: "Atendimento",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_VeterinarioId",
                table: "Atendimento",
                column: "VeterinarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamento");

            migrationBuilder.DropTable(
                name: "Atendimento");

            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "Veterinario");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "TipoAnimal");
        }
    }
}
