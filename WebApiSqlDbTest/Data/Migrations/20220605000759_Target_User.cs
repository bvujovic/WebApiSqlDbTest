using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiSqlDbTest.Migrations
{
    public partial class Target_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Targets",
                table: "Targets");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Targets",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Targets",
                newName: "OwnerUserId");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerUserId",
                table: "Targets",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "TargetId",
                table: "Targets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Targets",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "TStamp",
                table: "Targets",
                type: "BLOB",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Targets",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Targets",
                table: "Targets",
                column: "TargetId");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Targets_OwnerUserId",
                table: "Targets",
                column: "OwnerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Targets_User_OwnerUserId",
                table: "Targets",
                column: "OwnerUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Targets_User_OwnerUserId",
                table: "Targets");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Targets",
                table: "Targets");

            migrationBuilder.DropIndex(
                name: "IX_Targets_OwnerUserId",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "TargetId",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "TStamp",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Targets");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Targets",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "OwnerUserId",
                table: "Targets",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Targets",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Targets",
                table: "Targets",
                column: "Id");
        }
    }
}
