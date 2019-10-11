using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectPFE.Migrations
{
    public partial class t55 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Fiche_Amende",
                table: "Amendes",
                type: "NVARCHAR(MAX)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Fiche_Amende",
                table: "Amendes",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(MAX)",
                oldNullable: true);
        }
    }
}
