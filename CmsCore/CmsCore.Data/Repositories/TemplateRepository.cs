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

        public IEnumerable<Template> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');

            var query = this.DbContext.Templates.AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    query = query.Where(p => p.Name.Contains(sSearch) || p.ViewName.Contains(sSearch) || p.AddedBy.ToString().Contains(sSearch) || p.ModifiedDate.ToString().Contains(sSearch));
                }
            }

            var allTemplates = query;



            IEnumerable<Template> filteredTemplates = allTemplates;



            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {

                    case 0:
                        filteredTemplates = filteredTemplates.OrderBy(p => p.Name);
                        break;
                    case 1:
                        filteredTemplates = filteredTemplates.OrderBy(p => p.ViewName);
                        break;
                    case 2:
                        filteredTemplates = filteredTemplates.OrderBy(c => c.AddedBy);
                        break;
                    case 3:
                        filteredTemplates = filteredTemplates.OrderBy(c => c.ModifiedDate);
                        break;
                    default:
                        filteredTemplates = filteredTemplates.OrderBy(c => c.Name);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {
                    case 0:
                        filteredTemplates = filteredTemplates.OrderByDescending(p => p.Name);
                        break;
                    case 1:
                        filteredTemplates = filteredTemplates.OrderByDescending(p => p.ViewName);
                        break;
                    case 2:
                        filteredTemplates = filteredTemplates.OrderByDescending(c => c.AddedBy);
                        break;
                    case 3:
                        filteredTemplates = filteredTemplates.OrderByDescending(c => c.ModifiedDate);
                        break;
                    default:
                        filteredTemplates = filteredTemplates.OrderByDescending(c => c.Name);
                        break;
                }
            }
            var displayedTemplates = filteredTemplates.Skip(displayStart);
            if (displayLength > 0)
            {
                displayedTemplates = displayedTemplates.Take(displayLength);
            }
            totalRecords = allTemplates.Count();
            totalDisplayRecords = filteredTemplates.Count();
            return displayedTemplates.ToList();
        }
    }
    public interface ITemplateRepository : IRepository<Template>
    {
        IEnumerable<Template> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
    }
}
