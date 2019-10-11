using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPFE.Models
{
    public class SuperAdmin
    {

        [Key]
        public Guid AdminId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
