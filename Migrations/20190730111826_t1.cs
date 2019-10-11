using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectPFE.Migrations
{
    public partial class t1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    roleSpecific = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    UserModification = table.Column<string>(nullable: true),
                    DateModification = table.Column<DateTime>(nullable: false),
                    roleSpecific = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(maxLength: 30, nullable: true),
                    Nom = table.Column<string>(maxLength: 30, nullable: true),
                    Cin = table.Column<string>(maxLength: 30, nullable: true),
                    Sexe = table.Column<string>(maxLength: 20, nullable: true),
                    Nationalite = table.Column<string>(nullable: true),
                    Date_Naisance = table.Column<DateTime>(nullable: false),
                    Adresse = table.Column<string>(nullable: true),
                    Ville = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    Codepostal = table.Column<string>(nullable: true),
                    Cellulaire = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Contact_Urgence = table.Column<string>(nullable: true),
                    Tel_Urgence = table.Column<string>(nullable: true),
                    Image = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    Courriel = table.Column<string>(maxLength: 50, nullable: true),
                    Note = table.Column<string>(nullable: true),
                    Statut = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    UserModification = table.Column<string>(nullable: true),
                    DateModification = table.Column<DateTime>(nullable: false),
                    SiteId = table.Column<Guid>(nullable: false),
                    Code_Site = table.Column<string>(maxLength: 30, nullable: false),
                    Nom_Site = table.Column<string>(maxLength: 40, nullable: false),
                    Ville = table.Column<string>(nullable: false),
                    Adresse = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    Code_postal = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Telecopieur = table.Column<string>(nullable: true),
                    Courriel = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.SiteId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicules",
                columns: table => new
                {
                    UserModification = table.Column<string>(nullable: true),
                    DateModification = table.Column<DateTime>(nullable: false),
                    VehiculeId = table.Column<Guid>(nullable: false),
                    Matricule = table.Column<string>(maxLength: 40, nullable: false),
                    Modele = table.Column<string>(nullable: true),
                    Marque = table.Column<string>(nullable: false),
                    Type_vehicule = table.Column<string>(nullable: false),
                    Annee = table.Column<string>(nullable: true),
                    Numero_chassis = table.Column<int>(nullable: false),
                    Couleur = table.Column<string>(nullable: true),
                    Nombre_porte = table.Column<int>(nullable: false),
                    Nombre_place = table.Column<int>(nullable: false),
                    Type_Carburent = table.Column<string>(nullable: true),
                    Transmission = table.Column<string>(nullable: true),
                    Puissance = table.Column<string>(nullable: true),
                    kilometrage = table.Column<float>(nullable: false),
                    Nombre_Chevaux = table.Column<int>(nullable: false),
                    Documents = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    Valide = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicules", x => x.VehiculeId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "conducteur",
                columns: table => new
                {
                    ConducteurId = table.Column<Guid>(nullable: false),
                    Prenom = table.Column<string>(maxLength: 30, nullable: false),
                    Nom = table.Column<string>(maxLength: 30, nullable: true),
                    Cin = table.Column<string>(maxLength: 30, nullable: true),
                    Sexe = table.Column<string>(maxLength: 20, nullable: true),
                    Nationalite = table.Column<string>(nullable: true),
                    Date_Naisance = table.Column<DateTime>(nullable: false),
                    Adresse = table.Column<string>(nullable: true),
                    Ville = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    Codepostal = table.Column<string>(nullable: true),
                    Cellulaire = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Contact_Urgence = table.Column<string>(nullable: true),
                    Tel_Urgence = table.Column<string>(nullable: true),
                    Image = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    Courriel = table.Column<string>(maxLength: 50, nullable: true),
                    SiteId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conducteur", x => x.ConducteurId);
                    table.ForeignKey(
                        name: "FK_conducteur_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "SiteId",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "Employees_Sites",
                columns: table => new
                {
                    UserModification = table.Column<string>(nullable: true),
                    DateModification = table.Column<DateTime>(nullable: false),
                    IdEmployee_Site = table.Column<Guid>(nullable: false),
                    employeeId = table.Column<string>(nullable: true),
                    SiteId = table.Column<Guid>(nullable: false),
                    statut = table.Column<string>(nullable: true),
                    date_debut = table.Column<DateTime>(nullable: false),
                    date_fin = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees_Sites", x => new { x.IdEmployee_Site, x.SiteId });
                    table.UniqueConstraint("AK_Employees_Sites_IdEmployee_Site", x => x.IdEmployee_Site);
                    table.ForeignKey(
                        name: "FK_Employees_Sites_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "SiteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Sites_Employees_employeeId",
                        column: x => x.employeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Constats",
                columns: table => new
                {
                    UserModification = table.Column<string>(nullable: true),
                    DateModification = table.Column<DateTime>(nullable: false),
                    ConstatId = table.Column<Guid>(nullable: false),
                    Réf_Constat = table.Column<string>(maxLength: 40, nullable: false),
                    Fiche_Constat = table.Column<byte[]>(nullable: true),
                    VehiculeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Constats", x => x.ConstatId);
                    table.ForeignKey(
                        name: "FK_Constats_Vehicules_VehiculeId",
                        column: x => x.VehiculeId,
                        principalTable: "Vehicules",
                        principalColumn: "VehiculeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contrats",
                columns: table => new
                {
                    UserModification = table.Column<string>(nullable: true),
                    DateModification = table.Column<DateTime>(nullable: false),
                    ContractId = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(maxLength: 30, nullable: false),
                    Ville = table.Column<string>(nullable: true),
                    fournissseur = table.Column<string>(nullable: true),
                    Prix = table.Column<double>(nullable: false),
                    Date_Vente = table.Column<DateTime>(nullable: false),
                    Date_Debut = table.Column<DateTime>(nullable: false),
                    Date_Fin = table.Column<DateTime>(nullable: false),
                    VehiculeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrats", x => x.ContractId);
                    table.ForeignKey(
                        name: "FK_Contrats_Vehicules_VehiculeId",
                        column: x => x.VehiculeId,
                        principalTable: "Vehicules",
                        principalColumn: "VehiculeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    UserModification = table.Column<string>(nullable: true),
                    DateModification = table.Column<DateTime>(nullable: false),
                    DocumentId = table.Column<Guid>(nullable: false),
                    titre = table.Column<string>(nullable: true),
                    choix = table.Column<string>(nullable: true),
                    fichier = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    VehiculeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => new { x.DocumentId, x.VehiculeId });
                    table.UniqueConstraint("AK_Documents_DocumentId", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK_Documents_Vehicules_VehiculeId",
                        column: x => x.VehiculeId,
                        principalTable: "Vehicules",
                        principalColumn: "VehiculeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sites_Vehicules",
                columns: table => new
                {
                    UserModification = table.Column<string>(nullable: true),
                    DateModification = table.Column<DateTime>(nullable: false),
                    VehiculeId = table.Column<Guid>(nullable: false),
                    SiteId = table.Column<Guid>(nullable: false),
                    date_début = table.Column<DateTime>(nullable: false),
                    date_fin = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites_Vehicules", x => new { x.SiteId, x.VehiculeId });
                    table.ForeignKey(
                        name: "FK_Sites_Vehicules_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "SiteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sites_Vehicules_Vehicules_VehiculeId",
                        column: x => x.VehiculeId,
                        principalTable: "Vehicules",
                        principalColumn: "VehiculeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Amendes",
                columns: table => new
                {
                    UserModification = table.Column<string>(nullable: true),
                    DateModification = table.Column<DateTime>(nullable: false),
                    AmendeId = table.Column<Guid>(nullable: false),
                    Num_Avis = table.Column<string>(maxLength: 40, nullable: false),
                    Date_Avis = table.Column<DateTime>(nullable: false),
                    Date_Infraction = table.Column<DateTime>(nullable: false),
                    Lieu_Infraction = table.Column<string>(nullable: false),
                    Montant = table.Column<float>(nullable: false),
                    Fiche_Amende = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Num_Agent = table.Column<string>(nullable: true),
                    CodeService_Agent = table.Column<string>(nullable: true),
                    creation = table.Column<DateTime>(nullable: false),
                    VehiculeId = table.Column<Guid>(nullable: true),
                    Id = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<string>(nullable: true),
                    statut = table.Column<int>(nullable: false),
                    ConducteurId = table.Column<Guid>(nullable: true),
                    siteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amendes", x => x.AmendeId);
                    table.ForeignKey(
                        name: "FK_Amendes_conducteur_ConducteurId",
                        column: x => x.ConducteurId,
                        principalTable: "conducteur",
                        principalColumn: "ConducteurId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Amendes_Employees_Id",
                        column: x => x.Id,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Amendes_Vehicules_VehiculeId",
                        column: x => x.VehiculeId,
                        principalTable: "Vehicules",
                        principalColumn: "VehiculeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Amendes_Sites_siteId",
                        column: x => x.siteId,
                        principalTable: "Sites",
                        principalColumn: "SiteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees_Vehicules",
                columns: table => new
                {
                    UserModification = table.Column<string>(nullable: true),
                    DateModification = table.Column<DateTime>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    conducteurId = table.Column<Guid>(nullable: false),
                    VehiculeId = table.Column<Guid>(nullable: false),
                    SiteId = table.Column<Guid>(nullable: false),
                    date_debut = table.Column<DateTime>(nullable: false),
                    date_fin = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees_Vehicules", x => new { x.Id, x.VehiculeId });
                    table.UniqueConstraint("AK_Employees_Vehicules_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Vehicules_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "SiteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Vehicules_Vehicules_VehiculeId",
                        column: x => x.VehiculeId,
                        principalTable: "Vehicules",
                        principalColumn: "VehiculeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Vehicules_conducteur_conducteurId",
                        column: x => x.conducteurId,
                        principalTable: "conducteur",
                        principalColumn: "ConducteurId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Amendes_ConducteurId",
                table: "Amendes",
                column: "ConducteurId");

            migrationBuilder.CreateIndex(
                name: "IX_Amendes_Id",
                table: "Amendes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Amendes_VehiculeId",
                table: "Amendes",
                column: "VehiculeId");

            migrationBuilder.CreateIndex(
                name: "IX_Amendes_siteId",
                table: "Amendes",
                column: "siteId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_conducteur_SiteId",
                table: "conducteur",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_ConducteurSite_fk_SiteSiteId",
                table: "ConducteurSite",
                column: "fk_SiteSiteId");

            migrationBuilder.CreateIndex(
                name: "IX_ConducteurSite_fk_conducteurId",
                table: "ConducteurSite",
                column: "fk_conducteurId");

            migrationBuilder.CreateIndex(
                name: "IX_Constats_VehiculeId",
                table: "Constats",
                column: "VehiculeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contrats_VehiculeId",
                table: "Contrats",
                column: "VehiculeId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_VehiculeId",
                table: "Documents",
                column: "VehiculeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Sites_SiteId",
                table: "Employees_Sites",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Sites_employeeId",
                table: "Employees_Sites",
                column: "employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Vehicules_SiteId",
                table: "Employees_Vehicules",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Vehicules_VehiculeId",
                table: "Employees_Vehicules",
                column: "VehiculeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Vehicules_conducteurId",
                table: "Employees_Vehicules",
                column: "conducteurId");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_Vehicules_VehiculeId",
                table: "Sites_Vehicules",
                column: "VehiculeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amendes");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ConducteurSite");

            migrationBuilder.DropTable(
                name: "Constats");

            migrationBuilder.DropTable(
                name: "Contrats");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Employees_Sites");

            migrationBuilder.DropTable(
                name: "Employees_Vehicules");

            migrationBuilder.DropTable(
                name: "Sites_Vehicules");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "conducteur");

            migrationBuilder.DropTable(
                name: "Vehicules");

            migrationBuilder.DropTable(
                name: "Sites");
        }
    }
}
