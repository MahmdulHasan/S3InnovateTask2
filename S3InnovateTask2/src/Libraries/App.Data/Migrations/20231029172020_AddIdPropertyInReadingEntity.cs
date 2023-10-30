using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Data.Migrations
{
    public partial class AddIdPropertyInReadingEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Reading",
                table: "Reading");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Reading",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reading",
                table: "Reading",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reading_BuildingId",
                table: "Reading",
                column: "BuildingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Reading",
                table: "Reading");

            migrationBuilder.DropIndex(
                name: "IX_Reading_BuildingId",
                table: "Reading");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Reading");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reading",
                table: "Reading",
                columns: new[] { "BuildingId", "ObjectId", "DataFieldId" });
        }
    }
}
