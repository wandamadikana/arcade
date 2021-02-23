using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wanda.Games.TicTacToe.DAL.Migrations
{
    public partial class PlayerSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Player",
                columns: new[] { "Id", "DateCreated", "LastUpdated", "PlayerDescription", "PlayerName", "Symbol" },
                values: new object[] { 1, new DateTime(2021, 2, 23, 2, 29, 56, 212, DateTimeKind.Local).AddTicks(1346), new DateTime(2021, 2, 23, 2, 29, 56, 214, DateTimeKind.Local).AddTicks(7256), "BB-8 (or Beebee-Ate) AKA droid", "Computer", "o" });

            migrationBuilder.InsertData(
                table: "Player",
                columns: new[] { "Id", "DateCreated", "LastUpdated", "PlayerDescription", "PlayerName", "Symbol" },
                values: new object[] { 2, new DateTime(2021, 2, 23, 2, 29, 56, 214, DateTimeKind.Local).AddTicks(8182), new DateTime(2021, 2, 23, 2, 29, 56, 214, DateTimeKind.Local).AddTicks(8209), "You AKA Human", "Player1", "x" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
