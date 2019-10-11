using ProjectPFE.Models.EntityDataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPFE.Models
{
    public class Constat:EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Guid ConstatId { get; set; }
        [Required]
        [MaxLength(40)]
        public string Réf_Constat { get; set; }
        public byte[] Fiche_Constat { get; set; }
        //forigen key
        [ForeignKey("VehiculeId")]
        public Vehicule vehicule { get; set; }
        public Guid VehiculeId { get; set; }

        /*[ForeignKey("Id")]
        public Employee Employee { get; set; }
        public Guid Id { get; set; }*/

        public Constat()
        {
            ConstatId = Guid.NewGuid();
        }
    }
}
