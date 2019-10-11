using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectPFE.Migrations
{
    public partial class t11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Vehicules_Employees_employeId",
                table: "Employees_Vehicules");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Vehicules_employeId",
                table: "Employees_Vehicules");

            migrationBuilder.DropColumn(
                name: "employeId",
                table: "Employees_Vehicules");

            migrationBuilder.AddColumn<Guid>(
                name: "conducteurId",
                table: "Employees_Vehicules",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Vehicules_conducteurId",
                table: "Employees_Vehicules",
                column: "conducteurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Vehicules_conducteur_conducteurId",
                table: "Employees_Vehicules",
                column: "conducteurId",
                principalTable: "conducteur",
                principalColumn: "ConducteurId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Vehicules_conducteur_conducteurId",
                table: "Employees_Vehicules");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Vehicules_conducteurId",
                table: "Employees_Vehicules");

            migrationBuilder.DropColumn(
                name: "conducteurId",
                table: "Employees_Vehicules");

            migrationBuilder.AddColumn<string>(
                name: "employeId",
                table: "Employees_Vehicules",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Vehicules_employeId",
                table: "Employees_Vehicules",
                column: "employeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Vehicules_Employees_employeId",
                table: "Employees_Vehicules",
                column: "employeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
