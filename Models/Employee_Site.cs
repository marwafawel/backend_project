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
    public class Employee_Site : EntityBase
    {
        
        [Key]
        public Guid IdEmployee_Site { get; set; }

         [ForeignKey("employee")]
         public string employeeId { get; set; }

         public Employee fk_Employee { get; set; }
       

        [ForeignKey("site")]
        public Guid SiteId { get; set; }
        public Site fk_Site { get; set; }

        public string statut { get; set; }

        public DateTime date_debut { get; set; }
        public DateTime date_fin { get; set; }


        public Employee_Site()
        {
            IdEmployee_Site = Guid.NewGuid();
        }

    }

}
