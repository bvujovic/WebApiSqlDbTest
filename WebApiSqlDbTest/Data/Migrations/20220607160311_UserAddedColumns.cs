using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiSqlDbTest.Migrations
{
    public partial class UserAddedColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Targets_Users_OwnerUserId",
                table: "Targets");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Targets",
                newName: "StrTags");

            migrationBuilder.RenameColumn(
                name: "Tags",
                table: "Targets",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "OwnerUserId",
                table: "Targets",
                newName: "UserOwnerUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Targets_OwnerUserId",
                table: "Targets",
                newName: "IX_Targets_UserOwnerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Targets_Users_UserOwnerUserId",
                table: "Targets",
                column: "UserOwnerUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Targets_Users_UserOwnerUserId",
                table: "Targets");

            migrationBuilder.RenameColumn(
                name: "UserOwnerUserId",
                table: "Targets",
                newName: "OwnerUserId");

            migrationBuilder.RenameColumn(
                name: "StrTags",
                table: "Targets",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Targets",
                newName: "Tags");

            migrationBuilder.RenameIndex(
                name: "IX_Targets_UserOwnerUserId",
                table: "Targets",
                newName: "IX_Targets_OwnerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Targets_Users_OwnerUserId",
                table: "Targets",
                column: "OwnerUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
