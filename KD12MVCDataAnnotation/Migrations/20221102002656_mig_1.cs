using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KD12MVCDataAnnotation.Migrations
{
    public partial class mig_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hastanes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HastaneAdı = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hastanes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Calisans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HastaneID = table.Column<int>(type: "int", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calisans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calisans_Hastanes_HastaneID",
                        column: x => x.HastaneID,
                        principalTable: "Hastanes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calisans_HastaneID",
                table: "Calisans",
                column: "HastaneID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calisans");

            migrationBuilder.DropTable(
                name: "Hastanes");
        }
    }
}
