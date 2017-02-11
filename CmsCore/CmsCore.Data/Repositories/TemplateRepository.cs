using CmsCore.Data.Infrastructure;
using CmsCore.Model.Entities;
using System.Collections.Generic;
using System.Linq;
using static CmsCore.Data.Repositories.TemplateRepository;

namespace CmsCore.Data.Repositories
{
    public class TemplateRepository : RepositoryBase<Template>, ITemplateRepository
    {
        public TemplateRepository(ApplicationDbContext dbContext):base(dbContext)
        { }  
    }
    public interface ITemplateRepository : IRepository<Template>
    {
        
    }
}
