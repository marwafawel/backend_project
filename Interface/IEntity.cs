using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPFE.Interface
{
    public interface IEntity
    {
       
        String UserModification { get; set; }
        DateTime DateModification { get; set; }
    }
}
