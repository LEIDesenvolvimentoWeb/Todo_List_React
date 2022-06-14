using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Data.Migrations
{
    public partial class MudarFotografiaParaFicheiro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fotografia",
                table: "ToDo",
                newName: "Ficheiro");

            migrationBuilder.UpdateData(
                table: "ToDo",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(2022, 6, 14, 21, 52, 11, 144, DateTimeKind.Local).AddTicks(1048));

            migrationBuilder.UpdateData(
                table: "ToDo",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCriacao",
                value: new DateTime(2022, 6, 14, 21, 52, 11, 144, DateTimeKind.Local).AddTicks(1058));

            migrationBuilder.UpdateData(
                table: "ToDo",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCriacao",
                value: new DateTime(2022, 6, 14, 21, 52, 11, 144, DateTimeKind.Local).AddTicks(1068));

            migrationBuilder.UpdateData(
                table: "ToDo",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataCriacao",
                value: new DateTime(2022, 6, 14, 21, 52, 11, 144, DateTimeKind.Local).AddTicks(1076));

            migrationBuilder.UpdateData(
                table: "ToDo",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataCriacao",
                value: new DateTime(2022, 6, 14, 21, 52, 11, 144, DateTimeKind.Local).AddTicks(1085));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ficheiro",
                table: "ToDo",
                newName: "Fotografia");

            migrationBuilder.UpdateData(
                table: "ToDo",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(2022, 6, 13, 21, 15, 25, 171, DateTimeKind.Local).AddTicks(3325));

            migrationBuilder.UpdateData(
                table: "ToDo",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCriacao",
                value: new DateTime(2022, 6, 13, 21, 15, 25, 171, DateTimeKind.Local).AddTicks(3330));

            migrationBuilder.UpdateData(
                table: "ToDo",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCriacao",
                value: new DateTime(2022, 6, 13, 21, 15, 25, 171, DateTimeKind.Local).AddTicks(3334));

            migrationBuilder.UpdateData(
                table: "ToDo",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataCriacao",
                value: new DateTime(2022, 6, 13, 21, 15, 25, 171, DateTimeKind.Local).AddTicks(3338));

            migrationBuilder.UpdateData(
                table: "ToDo",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataCriacao",
                value: new DateTime(2022, 6, 13, 21, 15, 25, 171, DateTimeKind.Local).AddTicks(3342));
        }
    }
}
