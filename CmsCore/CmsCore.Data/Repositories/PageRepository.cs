using CmsCore.Data.Infrastructure;
using CmsCore.Model.Entities;

namespace CmsCore.Data.Repositories
{
    public class PageRepository : RepositoryBase<Page>, IPageRepository
    {
        public PageRepository(IDbFactory dbFactory)
                : base(dbFactory) { }  
        
        public Page GetBySlug(string slug)
        {
            slug = slug.ToLower();
            return Get(p => p.Slug == slug);
        }
    }
    public interface IPageRepository : IRepository<Page>
    {
        Page GetBySlug(string slug);
    }
}


