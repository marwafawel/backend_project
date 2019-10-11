using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectPFE.Migrations
{
    public partial class t12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConducteurSite",
                columns: table => new
                {
                    UserModification = table.Column<string>(nullable: true),
                    DateModification = table.Column<DateTime>(nullable: false),
                    id = table.Column<Guid>(nullable: false),
                    conducteur = table.Column<Guid>(nullable: false),
                    fk_conducteurId = table.Column<string>(nullable: true),
                    site = table.Column<Guid>(nullable: false),
                    fk_SiteSiteId = table.Column<Guid>(nullable: true),
                    date_debut = table.Column<DateTime>(nullable: false),
                    date_fin = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConducteurSite", x => x.id);
                    table.ForeignKey(
                        name: "FK_ConducteurSite_Sites_fk_SiteSiteId",
                        column: x => x.fk_SiteSiteId,
                        principalTable: "Sites",
                        principalColumn: "SiteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConducteurSite_Employees_fk_conducteurId",
                        column: x => x.fk_conducteurId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConducteurSite_fk_SiteSiteId",
                table: "ConducteurSite",
                column: "fk_SiteSiteId");

            migrationBuilder.CreateIndex(
                name: "IX_ConducteurSite_fk_conducteurId",
                table: "ConducteurSite",
                column: "fk_conducteurId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConducteurSite");
        }
    }
}
