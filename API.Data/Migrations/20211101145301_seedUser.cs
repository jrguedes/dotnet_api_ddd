using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class seedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Role", "UpdatedAt" },
                values: new object[] { new Guid("e0055e56-aaf5-4084-abb9-e5e4ad9af58c"), new DateTime(2021, 11, 1, 11, 53, 0, 599, DateTimeKind.Local).AddTicks(2830), "gerente@gmail.com", "Gerente", "Manager", new DateTime(2021, 11, 1, 11, 53, 0, 653, DateTimeKind.Local).AddTicks(7390) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e0055e56-aaf5-4084-abb9-e5e4ad9af58c"));
        }
    }
}
