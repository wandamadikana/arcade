using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wanda.Games.TicTacToe.DAL.Migrations
{
    public partial class makingplayerIdnotRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "Move",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastUpdated" },
                values: new object[] { new DateTime(2021, 2, 24, 4, 26, 14, 552, DateTimeKind.Local).AddTicks(6722), new DateTime(2021, 2, 24, 4, 26, 14, 554, DateTimeKind.Local).AddTicks(3737) });

            migrationBuilder.UpdateData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "LastUpdated" },
                values: new object[] { new DateTime(2021, 2, 24, 4, 26, 14, 554, DateTimeKind.Local).AddTicks(4457), new DateTime(2021, 2, 24, 4, 26, 14, 554, DateTimeKind.Local).AddTicks(4472) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "Move",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastUpdated" },
                values: new object[] { new DateTime(2021, 2, 23, 10, 16, 13, 564, DateTimeKind.Local).AddTicks(2291), new DateTime(2021, 2, 23, 10, 16, 13, 568, DateTimeKind.Local).AddTicks(4660) });

            migrationBuilder.UpdateData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "LastUpdated" },
                values: new object[] { new DateTime(2021, 2, 23, 10, 16, 13, 568, DateTimeKind.Local).AddTicks(5585), new DateTime(2021, 2, 23, 10, 16, 13, 568, DateTimeKind.Local).AddTicks(5612) });
        }
    }
}
