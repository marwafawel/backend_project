using ProjectPFE.Models.EntityDataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPFE.Models
{
    public class Document : EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Guid DocumentId { get; set; }
        public string titre { get; set; }
        public string choix { get; set; }
        [Column(TypeName = "NVARCHAR(MAX)")]
        public string fichier { get; set; }

        //  [ForeignKey("VehiculeId")]


        [ForeignKey("vehicule")]
        public Guid VehiculeId { get; set; }
        public Vehicule vehicule { get; set; }
        public Document()
        {
            DocumentId = Guid.NewGuid();
        }
    }



    



    
}
