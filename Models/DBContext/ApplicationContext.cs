using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectPFE.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ProjectPFE.Models.DBContext
{
    //le context va herite  de la class IdentityDbContext<User> qui contient les tableau génerer par l identity comme super admin , manger ,,
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Vehicule> Vehicules { get; set; }
        public DbSet<Contract> Contrats { get; set; }
        public DbSet<Constat> Constats { get; set; }
        public DbSet<Amende> Amendes { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Employee_Site> Employees_Sites { get; set; }
        public DbSet<Conducteur_vehicule> Employees_Vehicules { get; set; }
        public DbSet<Site_Vehicule> Sites_Vehicules { get; set; }
        public DbSet<ConducteurSite> ConducteurSite { get; set; }


        //fluent Api

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //many_to_many relationship
            //Employee_site entity
            modelBuilder.Entity<Employee_Site>().HasKey(sc => new { sc.IdEmployee_Site, sc.SiteId });
          

            //employee_site and employee (one to many)
            modelBuilder.Entity<Employee_Site>()
                .HasOne<Site>(sc => sc.fk_Site)
                .WithMany(s => s.Employee_Site)
                .HasForeignKey(sc => sc.SiteId);

            //***************************************************************************

            //Conducteur_Vehicule entity
            modelBuilder.Entity<Conducteur_vehicule>().HasKey(sc => new { sc.Id, sc.VehiculeId });

            //***********************************************************************************
            //Site_Vehicule entity
            modelBuilder.Entity<Site_Vehicule>().HasKey(sc => new { sc.SiteId, sc.VehiculeId });

            //employee_Vehicule and employee (one to many)
            modelBuilder.Entity<Site_Vehicule>()
                .HasOne<Site>(sc => sc.fk_Site)
                .WithMany(s => s.Site_Vehicule)
                .HasForeignKey(sc => sc.SiteId);

            //employee_Vehicule and Vehicule (one to many)
            modelBuilder.Entity<Site_Vehicule>()
                .HasOne<Vehicule>(sc => sc.fk_Vehicule)
                .WithMany(s => s.Site_Vehicule)
                .HasForeignKey(sc => sc.VehiculeId);


            //employee_site and employee (one to many)
            modelBuilder.Entity<Employee_Site>()
                .HasOne<Employee>(sc => sc.fk_Employee)
                .WithMany(s => s.Employee_Site)
                .HasForeignKey(sc => sc.employeeId);


            //employee_Vehicule and employee (one to many)
            modelBuilder.Entity<Conducteur_vehicule>()
                .HasOne<conducteur>(sc => sc.fk_conducteur)
                .WithMany(s => s.conducteur_vehicule)
                .HasForeignKey(sc => sc.conducteurId);

            //employee_Vehicule and Vehicule (one to many)
            modelBuilder.Entity<Conducteur_vehicule>()
                .HasOne<Vehicule>(sc => sc.fk_vehicule)
                .WithMany(s => s.Conducteur_Vehicule)
                .HasForeignKey(sc => sc.VehiculeId);




            //doc
            modelBuilder.Entity<Document>()
               .HasKey(c => new { c.DocumentId, c.VehiculeId });

        }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public ApplicationContext()
        {
        }

        public DbSet<ProjectPFE.Models.conducteur> conducteur { get; set; }

        








    }
}
