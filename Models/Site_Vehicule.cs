using ProjectPFE.Models.EntityDataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPFE.Models
{
    public class Site_Vehicule : EntityBase
    {
        [Key, Column(Order = 0)]
        public Guid VehiculeId { get; set; }
        //réf forigen key
        public Vehicule fk_Vehicule { get; set; }
        
        [Key, Column(Order = 1)]
        public Guid SiteId { get; set; }
        //réf forigen key
        public Site fk_Site { get; set; }

        public DateTime date_début { get; set; }
        public DateTime date_fin { get; set; }
    }
}
