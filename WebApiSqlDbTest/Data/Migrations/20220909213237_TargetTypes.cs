using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiSqlDbTest.Migrations
{
    public partial class TargetTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Targets",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Targets");
        }
    }
}
