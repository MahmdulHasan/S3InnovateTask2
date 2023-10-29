using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataField",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataField", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Object",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Object", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reading",
                columns: table => new
                {
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    ObjectId = table.Column<int>(type: "int", nullable: false),
                    DataFieldId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reading", x => new { x.BuildingId, x.ObjectId, x.DataFieldId });
                    table.ForeignKey(
                        name: "FK_Reading_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Building",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reading_DataField_DataFieldId",
                        column: x => x.DataFieldId,
                        principalTable: "DataField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reading_Object_ObjectId",
                        column: x => x.ObjectId,
                        principalTable: "Object",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reading_DataFieldId",
                table: "Reading",
                column: "DataFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Reading_ObjectId",
                table: "Reading",
                column: "ObjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reading");

            migrationBuilder.DropTable(
                name: "Building");

            migrationBuilder.DropTable(
                name: "DataField");

            migrationBuilder.DropTable(
                name: "Object");
        }
    }
}
