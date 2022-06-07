using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiSqlDbTest.Migrations
{
    public partial class Targets_NoTStamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TStamp",
                table: "Targets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "TStamp",
                table: "Targets",
                type: "BLOB",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
