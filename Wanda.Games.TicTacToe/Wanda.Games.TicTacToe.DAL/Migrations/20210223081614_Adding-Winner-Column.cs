using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wanda.Games.TicTacToe.DAL.Migrations
{
    public partial class AddingWinnerColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Winner",
                table: "Game",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Winner",
                table: "Game");

            migrationBuilder.UpdateData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastUpdated" },
                values: new object[] { new DateTime(2021, 2, 23, 2, 29, 56, 212, DateTimeKind.Local).AddTicks(1346), new DateTime(2021, 2, 23, 2, 29, 56, 214, DateTimeKind.Local).AddTicks(7256) });

            migrationBuilder.UpdateData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "LastUpdated" },
                values: new object[] { new DateTime(2021, 2, 23, 2, 29, 56, 214, DateTimeKind.Local).AddTicks(8182), new DateTime(2021, 2, 23, 2, 29, 56, 214, DateTimeKind.Local).AddTicks(8209) });
        }
    }
}
