using ProjectPFE.Models.EntityDataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPFE.Models
{
    public class Contract:EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Guid ContractId { get; set; }
        [Required]
        [MaxLength(30)]
        public string Type { get; set; }
        public string Ville { get; set; }
        public string fournissseur { get; set; }

        public double Prix { get; set; }
        public DateTime Date_Vente { get; set; }
        public DateTime Date_Debut { get; set; }
        public DateTime Date_Fin { get; set; }


        [ForeignKey("VehiculeId")]
        public Vehicule vehicule { get; set; }
        public Guid VehiculeId { get; set; }


        public Contract()
        {
            ContractId = Guid.NewGuid();
        }
    }
}
