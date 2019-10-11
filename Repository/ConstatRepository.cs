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
    public class ConstatRepository : RepositoryBase<Constat>, IConstatRepository
    {
        public ConstatRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
