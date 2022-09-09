using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiSqlDbTest.Migrations
{
    public partial class SharingUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Sharing",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_Email",
                table: "Users",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Sharing_UserId",
                table: "Sharing",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sharing_Users_UserId",
                table: "Sharing",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sharing_Users_UserId",
                table: "Sharing");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Sharing_UserId",
                table: "Sharing");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Sharing");
        }
    }
}
