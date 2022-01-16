using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Data.Migrations
{
    public partial class SpaceshipMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SpaceshipId",
                table: "ExistingFilePath",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Spaceship",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mass = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Crew = table.Column<int>(type: "int", nullable: false),
                    ConstructedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spaceship", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExistingFilePath_SpaceshipId",
                table: "ExistingFilePath",
                column: "SpaceshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExistingFilePath_Spaceship_SpaceshipId",
                table: "ExistingFilePath",
                column: "SpaceshipId",
                principalTable: "Spaceship",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExistingFilePath_Spaceship_SpaceshipId",
                table: "ExistingFilePath");

            migrationBuilder.DropTable(
                name: "Spaceship");

            migrationBuilder.DropIndex(
                name: "IX_ExistingFilePath_SpaceshipId",
                table: "ExistingFilePath");

            migrationBuilder.DropColumn(
                name: "SpaceshipId",
                table: "ExistingFilePath");
        }
    }
}
