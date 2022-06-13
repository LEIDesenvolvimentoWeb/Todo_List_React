using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDoType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToDo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataParaConcluir = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataConclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TipoId = table.Column<int>(type: "int", nullable: false),
                    Fotografia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDo_ToDoType_TipoId",
                        column: x => x.TipoId,
                        principalTable: "ToDoType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ToDoType",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 1, "Escola" });

            migrationBuilder.InsertData(
                table: "ToDoType",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 2, "Trabalhos" });

            migrationBuilder.InsertData(
                table: "ToDoType",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 3, "Outros" });

            migrationBuilder.InsertData(
                table: "ToDo",
                columns: new[] { "Id", "DataConclusao", "DataCriacao", "DataParaConcluir", "Descricao", "Fotografia", "TipoId", "Titulo" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2022, 6, 13, 21, 15, 25, 171, DateTimeKind.Local).AddTicks(3325), new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fazer a aplicação de Adoções", null, 1, "Trabalho de MVC" },
                    { 2, null, new DateTime(2022, 6, 13, 21, 15, 25, 171, DateTimeKind.Local).AddTicks(3330), new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fazer o FE com a api ToDo", null, 1, "Trabalho de React" },
                    { 3, null, new DateTime(2022, 6, 13, 21, 15, 25, 171, DateTimeKind.Local).AddTicks(3334), new DateTime(2022, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ficha número 3", null, 1, "Trabalho de Redes" },
                    { 4, new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 13, 21, 15, 25, 171, DateTimeKind.Local).AddTicks(3338), new DateTime(2022, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ficha número 8", null, 1, "Fichas de Base de Dados" },
                    { 5, new DateTime(2022, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 13, 21, 15, 25, 171, DateTimeKind.Local).AddTicks(3342), new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ficha número 4", null, 1, "Fichas de Sistemas Operativos" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDo_TipoId",
                table: "ToDo",
                column: "TipoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDo");

            migrationBuilder.DropTable(
                name: "ToDoType");
        }
    }
}
