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
    public class DocumentRepository : RepositoryBase<Document>, IDocumentRepository
    {
        private readonly ApplicationContext _dbContext;
        public DocumentRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

       

     










    }
}
