using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjectPFE.Models.EntityDataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPFE.Models
{
    //joining table
    public class ConducteurSite : EntityBase
    {
        [Key]
        public Guid id { get; set; }

         [ForeignKey("conducteur")]
         public Guid conducteur { get; set; }

         public Employee fk_conducteur { get; set; }
       

        [ForeignKey("site")]
        public Guid site { get; set; }
        public Site fk_Site { get; set; }

        public DateTime date_debut { get; set; }
        public DateTime date_fin { get; set; }


        public ConducteurSite()
        {
            id = Guid.NewGuid();
        }

    }

}
