using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPFE.Models
{
    public class User: IdentityUser
    {
        [Key]
        //public Guid Id { get; set; }
        //public string Login { get; set; }
        [NotMapped]
        public string Password { get; set; }

        public string roleSpecific { get; set; }
    }
}
