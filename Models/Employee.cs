using Microsoft.AspNetCore.Identity;
using ProjectPFE.Models.EntityDataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;





namespace ProjectPFE.Models
{
    public class Employee: IdentityUser
    {
        public string UserModification { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateModification { get; set; } = DateTime.Now;

        [NotMapped]
        public string Password { get; set; }

        public string roleSpecific { get; set; }

        
        
        [MaxLength(30)]
        public string Prenom { get; set; }
        
        [MaxLength(30)]
        public string Nom { get; set; }
        
        [MaxLength(30)]
        public string Cin { get; set; }
        
        [MaxLength(20)]
        public string Sexe { get; set; }
        
        public string Nationalite { get; set; }
        
        public DateTime Date_Naisance { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string Province { get; set; }
        public string Codepostal { get; set; }
        
        public string Cellulaire { get; set; }
        public string Telephone { get; set; }
        public string Contact_Urgence { get; set; }
        public string Tel_Urgence { get; set; }

        [Column(TypeName = "NVARCHAR(MAX)")]
        public string Image { get; set; }
        
        [EmailAddress]
        [MaxLength(50)]
        public string Courriel { get; set; }
        public string Note { get; set; }
        
        public string Statut { get; set; }

        //public ICollection<Constat> Constat { get; set; }
        public ICollection<Amende> Amende { get; set; }
        public IList<Employee_Site> Employee_Site { get; set; }

        public Employee()
        {
        }
    }
}
