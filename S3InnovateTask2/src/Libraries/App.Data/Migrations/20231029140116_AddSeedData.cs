using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Data.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Building",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Location 1", "Building 1" },
                    { 2, "Location 2", "Building 2" }
                });

            migrationBuilder.InsertData(
                table: "DataField",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "DataField 1" },
                    { 2, "DataField 2" }
                });

            migrationBuilder.InsertData(
                table: "Object",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Object 1" },
                    { 2, "Object 2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Building",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Building",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DataField",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DataField",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Object",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Object",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
