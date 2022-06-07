using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiSqlDbTest.Migrations
{
    public partial class UserAddedColumns2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Targets_Users_UserOwnerUserId",
                table: "Targets");

            migrationBuilder.RenameColumn(
                name: "UserOwnerUserId",
                table: "Targets",
                newName: "UserOwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Targets_UserOwnerUserId",
                table: "Targets",
                newName: "IX_Targets_UserOwnerId");

            migrationBuilder.AddColumn<DateTime>(
                name: "AccessedDate",
                table: "Targets",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Targets",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UserAccessedId",
                table: "Targets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserModifiedId",
                table: "Targets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Targets_UserAccessedId",
                table: "Targets",
                column: "UserAccessedId");

            migrationBuilder.CreateIndex(
                name: "IX_Targets_UserModifiedId",
                table: "Targets",
                column: "UserModifiedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Targets_Users_UserAccessedId",
                table: "Targets",
                column: "UserAccessedId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Targets_Users_UserModifiedId",
                table: "Targets",
                column: "UserModifiedId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Targets_Users_UserOwnerId",
                table: "Targets",
                column: "UserOwnerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Targets_Users_UserAccessedId",
                table: "Targets");

            migrationBuilder.DropForeignKey(
                name: "FK_Targets_Users_UserModifiedId",
                table: "Targets");

            migrationBuilder.DropForeignKey(
                name: "FK_Targets_Users_UserOwnerId",
                table: "Targets");

            migrationBuilder.DropIndex(
                name: "IX_Targets_UserAccessedId",
                table: "Targets");

            migrationBuilder.DropIndex(
                name: "IX_Targets_UserModifiedId",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "AccessedDate",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "UserAccessedId",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "UserModifiedId",
                table: "Targets");

            migrationBuilder.RenameColumn(
                name: "UserOwnerId",
                table: "Targets",
                newName: "UserOwnerUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Targets_UserOwnerId",
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
    }
}
