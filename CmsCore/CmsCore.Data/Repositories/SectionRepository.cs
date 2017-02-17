using CmsCore.Data.Infrastructure;
using CmsCore.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Data.Repositories
{
    public class SectionRepository : RepositoryBase<Section>, ISectionRepository
    {

        public SectionRepository(ApplicationDbContext dbContext)
                : base(dbContext) { }
        public IEnumerable<Section> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');

            var query = this.DbContext.Sections.Include(m => m.Widgets).AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    query = query.Where(p => p.Id.ToString().Contains(sSearch) || p.Name.Contains(sSearch));
                }
            }

            var allSections = query;
            IEnumerable<Section> filteredSections = allSections;
            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredSections = filteredSections.OrderBy(p => p.Id);
                        break;
                    case 2:
                        filteredSections = filteredSections.OrderBy(p => p.Name);
                        break;
                    
                    default:
                        filteredSections = filteredSections.OrderBy(c => c.Id);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredSections = filteredSections.OrderByDescending(p => p.Id);
                        break;
                    case 2:
                        filteredSections = filteredSections.OrderByDescending(p => p.Name);
                        break;
                    default:
                        filteredSections = filteredSections.OrderByDescending(c => c.Id);
                        break;
                }
            }
            var displayedSections = filteredSections.Skip(displayStart);
            if (displayLength > 0)
            {
                displayedSections = displayedSections.Take(displayLength);
            }
            totalRecords = allSections.Count();
            totalDisplayRecords = filteredSections.Count();
            return displayedSections.ToList();
        }

    }
    public interface ISectionRepository : IRepository<Section>
    {
        IEnumerable<Section> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
    }
}
