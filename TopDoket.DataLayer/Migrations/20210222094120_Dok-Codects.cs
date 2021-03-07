using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TopDoket.DataLayer.Migrations
{
    public partial class DokCodects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    DiscountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountCode = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DiscountPercent = table.Column<int>(type: "int", nullable: false),
                    UsableCount = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.DiscountId);
                });

            migrationBuilder.CreateTable(
                name: "UserDiscountCodes",
                columns: table => new
                {
                    UD_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DiscountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDiscountCodes", x => x.UD_Id);
                    table.ForeignKey(
                        name: "FK_UserDiscountCodes_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "DiscountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserDiscountCodes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserDiscountCodes_DiscountId",
                table: "UserDiscountCodes",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDiscountCodes_UserId",
                table: "UserDiscountCodes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDiscountCodes");

            migrationBuilder.DropTable(
                name: "Discounts");
        }
    }
}
