using ProjectPFE.Models.EntityDataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPFE.Models
{
    public class Conducteur_vehicule : EntityBase
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("conducteur")]
        public Guid conducteurId { get; set; }
        public conducteur fk_conducteur { get; set; }

        [ForeignKey("Vehicule")]
        public Guid VehiculeId { get; set; }
        public Vehicule fk_vehicule { get; set; }

        [ForeignKey("site")]
        public Guid SiteId { get; set; }
        public Site fk_Site { get; set; }
       

        public DateTime date_debut { get; set; }
        public DateTime date_fin { get; set; }


        public Conducteur_vehicule()
        {
            Id = Guid.NewGuid();
        }

    }
}
