using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Migrations
{
    public partial class Correcoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataConclusão",
                table: "ToDo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataParaConcluir",
                table: "ToDo",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataConclusao",
                table: "ToDo",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "ToDo",
                columns: new[] { "Id", "DataConclusao", "DataCriacao", "DataParaConcluir", "Descricao", "Titulo" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2022, 5, 30, 22, 24, 9, 611, DateTimeKind.Local).AddTicks(9778), new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fazer a aplicação de Adoções", "Trabalho de MVC" },
                    { 2, null, new DateTime(2022, 5, 30, 22, 24, 9, 611, DateTimeKind.Local).AddTicks(9825), new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fazer o FE com a api ToDo", "Trabalho de React" },
                    { 3, null, new DateTime(2022, 5, 30, 22, 24, 9, 611, DateTimeKind.Local).AddTicks(9827), new DateTime(2022, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ficha número 3", "Trabalho de Redes" },
                    { 4, new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 30, 22, 24, 9, 611, DateTimeKind.Local).AddTicks(9830), new DateTime(2022, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ficha número 8", "Fichas de Base de Dados" },
                    { 5, new DateTime(2022, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 30, 22, 24, 9, 611, DateTimeKind.Local).AddTicks(9832), new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ficha número 4", "Fichas de Sistemas Operativos" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDo",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ToDo",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ToDo",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ToDo",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ToDo",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "DataConclusao",
                table: "ToDo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataParaConcluir",
                table: "ToDo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataConclusão",
                table: "ToDo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
