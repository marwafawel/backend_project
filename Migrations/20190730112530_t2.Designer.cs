﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectPFE.Models.DBContext;

namespace ProjectPFE.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20190730112530_t2")]
    partial class t2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ProjectPFE.Models.Amende", b =>
                {
                    b.Property<Guid>("AmendeId");

                    b.Property<string>("CodeService_Agent");

                    b.Property<Guid?>("ConducteurId");

                    b.Property<DateTime>("DateModification");

                    b.Property<DateTime>("Date_Avis");

                    b.Property<DateTime>("Date_Infraction");

                    b.Property<string>("Description");

                    b.Property<string>("EmployeeId");

                    b.Property<string>("Fiche_Amende")
                        .HasColumnType("NVARCHAR(MAX)");

                    b.Property<string>("Id");

                    b.Property<string>("Lieu_Infraction")
                        .IsRequired();

                    b.Property<float>("Montant");

                    b.Property<string>("Num_Agent");

                    b.Property<string>("Num_Avis")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("UserModification");

                    b.Property<Guid?>("VehiculeId");

                    b.Property<DateTime>("creation");

                    b.Property<Guid>("siteId");

                    b.Property<int>("statut");

                    b.HasKey("AmendeId");

                    b.HasIndex("ConducteurId");

                    b.HasIndex("Id");

                    b.HasIndex("VehiculeId");

                    b.HasIndex("siteId");

                    b.ToTable("Amendes");
                });

            modelBuilder.Entity("ProjectPFE.Models.conducteur", b =>
                {
                    b.Property<Guid>("ConducteurId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresse");

                    b.Property<string>("Cellulaire");

                    b.Property<string>("Cin")
                        .HasMaxLength(30);

                    b.Property<string>("Codepostal");

                    b.Property<string>("Contact_Urgence");

                    b.Property<string>("Courriel")
                        .HasMaxLength(50);

                    b.Property<DateTime>("Date_Naisance");

                    b.Property<string>("Image")
                        .HasColumnType("NVARCHAR(MAX)");

                    b.Property<string>("Nationalite");

                    b.Property<string>("Nom")
                        .HasMaxLength(30);

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Province");

                    b.Property<string>("Sexe")
                        .HasMaxLength(20);

                    b.Property<Guid?>("SiteId");

                    b.Property<string>("Tel_Urgence");

                    b.Property<string>("Telephone");

                    b.Property<string>("Ville");

                    b.HasKey("ConducteurId");

                    b.HasIndex("SiteId");

                    b.ToTable("conducteur");
                });

            modelBuilder.Entity("ProjectPFE.Models.Conducteur_vehicule", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<Guid>("VehiculeId");

                    b.Property<DateTime>("DateModification");

                    b.Property<Guid>("SiteId");

                    b.Property<string>("UserModification");

                    b.Property<Guid>("conducteurId");

                    b.Property<DateTime>("date_debut");

                    b.Property<DateTime>("date_fin");

                    b.HasKey("Id", "VehiculeId");

                    b.HasAlternateKey("Id");

                    b.HasIndex("SiteId");

                    b.HasIndex("VehiculeId");

                    b.HasIndex("conducteurId");

                    b.ToTable("Employees_Vehicules");
                });

            modelBuilder.Entity("ProjectPFE.Models.ConducteurSite", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateModification");

                    b.Property<string>("UserModification");

                    b.Property<Guid>("conducteur");

                    b.Property<DateTime>("date_debut");

                    b.Property<DateTime>("date_fin");

                    b.Property<Guid?>("fk_SiteSiteId");

                    b.Property<string>("fk_conducteurId");

                    b.Property<Guid>("site");

                    b.HasKey("id");

                    b.HasIndex("fk_SiteSiteId");

                    b.HasIndex("fk_conducteurId");

                    b.ToTable("ConducteurSite");
                });

            modelBuilder.Entity("ProjectPFE.Models.Constat", b =>
                {
                    b.Property<Guid>("ConstatId");

                    b.Property<DateTime>("DateModification");

                    b.Property<byte[]>("Fiche_Constat");

                    b.Property<string>("Réf_Constat")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("UserModification");

                    b.Property<Guid>("VehiculeId");

                    b.HasKey("ConstatId");

                    b.HasIndex("VehiculeId");

                    b.ToTable("Constats");
                });

            modelBuilder.Entity("ProjectPFE.Models.Contract", b =>
                {
                    b.Property<Guid>("ContractId");

                    b.Property<DateTime>("DateModification");

                    b.Property<DateTime>("Date_Debut");

                    b.Property<DateTime>("Date_Fin");

                    b.Property<DateTime>("Date_Vente");

                    b.Property<double>("Prix");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("UserModification");

                    b.Property<Guid>("VehiculeId");

                    b.Property<string>("Ville");

                    b.Property<string>("fournissseur");

                    b.HasKey("ContractId");

                    b.HasIndex("VehiculeId");

                    b.ToTable("Contrats");
                });

            modelBuilder.Entity("ProjectPFE.Models.Document", b =>
                {
                    b.Property<Guid>("DocumentId");

                    b.Property<Guid>("VehiculeId");

                    b.Property<DateTime>("DateModification");

                    b.Property<string>("UserModification");

                    b.Property<string>("choix");

                    b.Property<string>("fichier")
                        .HasColumnType("NVARCHAR(MAX)");

                    b.Property<string>("titre");

                    b.HasKey("DocumentId", "VehiculeId");

                    b.HasAlternateKey("DocumentId");

                    b.HasIndex("VehiculeId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("ProjectPFE.Models.Employee", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Adresse");

                    b.Property<string>("Cellulaire");

                    b.Property<string>("Cin")
                        .HasMaxLength(30);

                    b.Property<string>("Codepostal");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Contact_Urgence");

                    b.Property<string>("Courriel")
                        .HasMaxLength(50);

                    b.Property<DateTime>("DateModification");

                    b.Property<DateTime>("Date_Naisance");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("Image")
                        .HasColumnType("NVARCHAR(MAX)");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Nationalite");

                    b.Property<string>("Nom")
                        .HasMaxLength(30);

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("Note");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("Prenom")
                        .HasMaxLength(30);

                    b.Property<string>("Province");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("Sexe")
                        .HasMaxLength(20);

                    b.Property<string>("Statut");

                    b.Property<string>("Tel_Urgence");

                    b.Property<string>("Telephone");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserModification");

                    b.Property<string>("UserName");

                    b.Property<string>("Ville");

                    b.Property<string>("roleSpecific");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ProjectPFE.Models.Employee_Site", b =>
                {
                    b.Property<Guid>("IdEmployee_Site");

                    b.Property<Guid>("SiteId");

                    b.Property<DateTime>("DateModification");

                    b.Property<string>("UserModification");

                    b.Property<DateTime>("date_debut");

                    b.Property<DateTime>("date_fin");

                    b.Property<string>("employeeId");

                    b.Property<string>("statut");

                    b.HasKey("IdEmployee_Site", "SiteId");

                    b.HasAlternateKey("IdEmployee_Site");

                    b.HasIndex("SiteId");

                    b.HasIndex("employeeId");

                    b.ToTable("Employees_Sites");
                });

            modelBuilder.Entity("ProjectPFE.Models.Site", b =>
                {
                    b.Property<Guid>("SiteId");

                    b.Property<string>("Adresse");

                    b.Property<string>("Code_Site")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Code_postal");

                    b.Property<string>("Courriel")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("DateModification");

                    b.Property<string>("Nom_Site")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("Province");

                    b.Property<string>("Telecopieur");

                    b.Property<string>("Telephone");

                    b.Property<string>("UserModification");

                    b.Property<string>("Ville")
                        .IsRequired();

                    b.HasKey("SiteId");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("ProjectPFE.Models.Site_Vehicule", b =>
                {
                    b.Property<Guid>("SiteId");

                    b.Property<Guid>("VehiculeId");

                    b.Property<DateTime>("DateModification");

                    b.Property<string>("UserModification");

                    b.Property<DateTime>("date_début");

                    b.Property<DateTime>("date_fin");

                    b.HasKey("SiteId", "VehiculeId");

                    b.HasIndex("VehiculeId");

                    b.ToTable("Sites_Vehicules");
                });

            modelBuilder.Entity("ProjectPFE.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<string>("roleSpecific");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ProjectPFE.Models.Vehicule", b =>
                {
                    b.Property<Guid>("VehiculeId");

                    b.Property<string>("Annee");

                    b.Property<string>("Couleur");

                    b.Property<DateTime>("DateModification");

                    b.Property<string>("Documents")
                        .HasColumnType("NVARCHAR(MAX)");

                    b.Property<string>("Marque")
                        .IsRequired();

                    b.Property<string>("Matricule")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("Modele");

                    b.Property<int>("Nombre_Chevaux");

                    b.Property<int>("Nombre_place");

                    b.Property<int>("Nombre_porte");

                    b.Property<int>("Numero_chassis");

                    b.Property<string>("Puissance");

                    b.Property<string>("Transmission");

                    b.Property<string>("Type_Carburent");

                    b.Property<string>("Type_vehicule")
                        .IsRequired();

                    b.Property<string>("UserModification");

                    b.Property<bool>("Valide");

                    b.Property<float>("kilometrage");

                    b.HasKey("VehiculeId");

                    b.ToTable("Vehicules");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ProjectPFE.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ProjectPFE.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectPFE.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ProjectPFE.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectPFE.Models.Amende", b =>
                {
                    b.HasOne("ProjectPFE.Models.conducteur", "conducteur")
                        .WithMany("Amende")
                        .HasForeignKey("ConducteurId");

                    b.HasOne("ProjectPFE.Models.Employee", "Employee")
                        .WithMany("Amende")
                        .HasForeignKey("Id");

                    b.HasOne("ProjectPFE.Models.Vehicule", "vehicule")
                        .WithMany("Amende")
                        .HasForeignKey("VehiculeId");

                    b.HasOne("ProjectPFE.Models.Site", "site")
                        .WithMany()
                        .HasForeignKey("siteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectPFE.Models.conducteur", b =>
                {
                    b.HasOne("ProjectPFE.Models.Site", "fk_Site")
                        .WithMany("conducteur")
                        .HasForeignKey("SiteId");
                });

            modelBuilder.Entity("ProjectPFE.Models.Conducteur_vehicule", b =>
                {
                    b.HasOne("ProjectPFE.Models.Site", "fk_Site")
                        .WithMany("Conducteur_Vehicule")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectPFE.Models.Vehicule", "fk_vehicule")
                        .WithMany("Conducteur_Vehicule")
                        .HasForeignKey("VehiculeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectPFE.Models.conducteur", "fk_conducteur")
                        .WithMany("conducteur_vehicule")
                        .HasForeignKey("conducteurId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectPFE.Models.ConducteurSite", b =>
                {
                    b.HasOne("ProjectPFE.Models.Site", "fk_Site")
                        .WithMany()
                        .HasForeignKey("fk_SiteSiteId");

                    b.HasOne("ProjectPFE.Models.Employee", "fk_conducteur")
                        .WithMany()
                        .HasForeignKey("fk_conducteurId");
                });

            modelBuilder.Entity("ProjectPFE.Models.Constat", b =>
                {
                    b.HasOne("ProjectPFE.Models.Vehicule", "vehicule")
                        .WithMany("Constat")
                        .HasForeignKey("VehiculeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectPFE.Models.Contract", b =>
                {
                    b.HasOne("ProjectPFE.Models.Vehicule", "vehicule")
                        .WithMany("Contracts")
                        .HasForeignKey("VehiculeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectPFE.Models.Document", b =>
                {
                    b.HasOne("ProjectPFE.Models.Vehicule", "vehicule")
                        .WithMany("Document")
                        .HasForeignKey("VehiculeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectPFE.Models.Employee_Site", b =>
                {
                    b.HasOne("ProjectPFE.Models.Site", "fk_Site")
                        .WithMany("Employee_Site")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectPFE.Models.Employee", "fk_Employee")
                        .WithMany("Employee_Site")
                        .HasForeignKey("employeeId");
                });

            modelBuilder.Entity("ProjectPFE.Models.Site_Vehicule", b =>
                {
                    b.HasOne("ProjectPFE.Models.Site", "fk_Site")
                        .WithMany("Site_Vehicule")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectPFE.Models.Vehicule", "fk_Vehicule")
                        .WithMany("Site_Vehicule")
                        .HasForeignKey("VehiculeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
