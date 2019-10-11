using Microsoft.EntityFrameworkCore;
using ProjectPFE.Interface.IRepositories;
using ProjectPFE.Models;
using ProjectPFE.Models.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPFE.Repository
{
    public class VehiculeRepository : RepositoryBase<Vehicule>, IVehiculeRepository
    {
        public VehiculeRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
