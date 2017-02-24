using CmsCore.Data.Infrastructure;
using CmsCore.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Data.Repositories
{
    public class LanguageRepository : RepositoryBase<Language>, ILanguageRepository
    {

        public LanguageRepository(ApplicationDbContext dbContext)
                : base(dbContext) { }
        public IEnumerable<Language> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');

            var query = this.DbContext.Languages.AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    query = query.Where(p => p.Id.ToString().Contains(sSearch) || p.Name.Contains(sSearch));
                }
            }

            var allLanguages = query;
            IEnumerable<Language> filteredLanguages = allLanguages;
            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredLanguages = filteredLanguages.OrderBy(p => p.Id);
                        break;
                    case 2:
                        filteredLanguages = filteredLanguages.OrderBy(p => p.Name);
                        break;
                   
                    default:
                        filteredLanguages = filteredLanguages.OrderBy(c => c.Id);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredLanguages = filteredLanguages.OrderByDescending(p => p.Id);
                        break;
                    case 2:
                        filteredLanguages = filteredLanguages.OrderByDescending(p => p.Name);
                        break;
                    
                      
                    default:
                        filteredLanguages = filteredLanguages.OrderByDescending(c => c.Id);
                        break;
                }
            }
            var displayedLanguages = filteredLanguages.Skip(displayStart);
            if (displayLength > 0)
            {
                displayedLanguages = displayedLanguages.Take(displayLength);
            }
            totalRecords = allLanguages.Count();
            totalDisplayRecords = filteredLanguages.Count();
            return displayedLanguages.ToList();
        }

    }
    public interface ILanguageRepository : IRepository<Language>
    {
        IEnumerable<Language> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
    }
}
