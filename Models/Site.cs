using ProjectPFE.Models.EntityDataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPFE.Models
{
    public class Site:EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Guid SiteId { get; set; }
        [Required]
        [MaxLength(30)]
        public string Code_Site { get; set; }
        [Required]
        [MaxLength(40)]
        public string Nom_Site { get; set; }

        [Required]
        public string Ville { get; set; }
        public string Adresse { get; set; }
        public string Province { get; set; }
        public string Code_postal { get; set; }
        public string Telephone { get; set; }
        public string Telecopieur { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Courriel { get; set; }
        public IList<Employee_Site> Employee_Site { get; set; }
        public IList<Site_Vehicule> Site_Vehicule { get; set; }
        public IList<Conducteur_vehicule> Conducteur_Vehicule { get; set; }
        public ICollection<conducteur> conducteur { get; set; }


        public Site()
        {
            SiteId = Guid.NewGuid();
        }
    }
}
