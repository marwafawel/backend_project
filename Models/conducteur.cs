using ProjectPFE.Models.EntityDataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPFE.Models
{
    public class conducteur : EntityBase
    {
        [Key]
        public Guid ConducteurId { get; set; }
        [Required]
        [MaxLength(30)]
        public string Prenom { get; set; }
       // [Required]
        [MaxLength(30)]
        public string Nom { get; set; }
       // [Required]
        [MaxLength(30)]
        public string Cin { get; set; }

        [MaxLength(20)]
        public string Sexe { get; set; }

        public string Nationalite { get; set; }
      //  [Required]
        public DateTime Date_Naisance { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string Province { get; set; }
        public string Codepostal { get; set; }
      //  [Required]
        public string Cellulaire { get; set; }
        public string Telephone { get; set; }
        public string Contact_Urgence { get; set; }
        public string Tel_Urgence { get; set; }

        [Column(TypeName = "NVARCHAR(MAX)")]
        public string Image { get; set; }
      //  [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Courriel { get; set; }
        public ICollection<Amende> Amende { get; set; }
        [ForeignKey("site")]
        public Guid? SiteId { get; set; }
        public Site fk_Site { get; set; }
        public IList<Conducteur_vehicule> conducteur_vehicule { get; set; }
        public conducteur()
        {
            ConducteurId = Guid.NewGuid();
        }

    }
}
