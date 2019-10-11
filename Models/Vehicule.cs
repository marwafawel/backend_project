using ProjectPFE.Models.EntityDataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPFE.Models
{
    public class Vehicule:EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Guid VehiculeId { get; set; }
        [Required]
        [MaxLength(40)]
        public string Matricule { get; set; }
        public string Modele { get; set; }
        [Required]
        public string Marque { get; set; }
        [Required]
        public string Type_vehicule { get; set; }
        public string Annee { get; set; }
        public int Numero_chassis { get; set; }
        public string Couleur { get; set; }
        public int Nombre_porte { get; set; }
        public int Nombre_place { get; set; }
        public string Type_Carburent { get; set; }
        public string Transmission { get; set; }
        public string Puissance { get; set; }
        public float kilometrage { get; set; }
        public int Nombre_Chevaux { get; set; }
       
       


        [Column(TypeName = "NVARCHAR(MAX)")]
        public string Documents { get; set; }
       
        public bool Valide { get; set; }

        public ICollection<Contract> Contracts { get; set; }
        public ICollection<Constat> Constat { get; set; }
        public ICollection<Amende> Amende { get; set; }
        public ICollection<Document> Document { get; set; }
        public IList<Conducteur_vehicule> Conducteur_Vehicule { get; set; }
        public IList<Site_Vehicule> Site_Vehicule { get; set; }
        public Vehicule()
        {
            VehiculeId = Guid.NewGuid();
        }
    }
}
