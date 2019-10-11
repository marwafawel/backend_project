using ProjectPFE.Interface.IRepositories;
using ProjectPFE.Models;
using ProjectPFE.Models.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPFE.Repository
{
    public class Conducteur_VehiculeRepository:RepositoryBase<Conducteur_vehicule>, IConducteur_VehiculeRepository
    {
        public Conducteur_VehiculeRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}

