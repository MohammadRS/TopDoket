using Microsoft.EntityFrameworkCore.Migrations;

namespace TopDoket.DataLayer.Migrations
{
    public partial class DokEpisodeIsDelet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "CourseEpisodes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "CourseEpisodes");
        }
    }
}
