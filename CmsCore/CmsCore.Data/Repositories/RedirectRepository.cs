using CmsCore.Data.Infrastructure;
using CmsCore.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Data.Repositories
{
    public class RedirectRepository : RepositoryBase<Redirect>, IRedirectRepository
    {

        public RedirectRepository(ApplicationDbContext dbContext)
                : base(dbContext) { }
        public IEnumerable<Redirect> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');

            var query = this.DbContext.Redirects.AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    query = query.Where(p => p.Id.ToString().Contains(sSearch) || p.Name.Contains(sSearch));
                }
            }

            var allRedirects = query;
            IEnumerable<Redirect> filteredRedirects = allRedirects;
            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredRedirects = filteredRedirects.OrderBy(p => p.Id);
                        break;
                    case 2:
                        filteredRedirects = filteredRedirects.OrderBy(p => p.OldUrl);
                        break;
                    case 3:
                        filteredRedirects = filteredRedirects.OrderBy(p => p.NewUrl);
                        break;
                   
                     
                    default:
                        filteredRedirects = filteredRedirects.OrderBy(c => c.Id);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredRedirects = filteredRedirects.OrderByDescending(p => p.Id);
                        break;
                    case 2:
                        filteredRedirects = filteredRedirects.OrderByDescending(p => p.OldUrl);
                        break;
                    case 3:
                        filteredRedirects = filteredRedirects.OrderByDescending(p => p.NewUrl);
                        break;
                  
                    default:
                        filteredRedirects = filteredRedirects.OrderByDescending(c => c.Id);
                        break;
                }
            }
            var displayedRedirects = filteredRedirects.Skip(displayStart);
            if (displayLength > 0)
            {
                displayedRedirects = displayedRedirects.Take(displayLength);
            }
            totalRecords = allRedirects.Count();
            totalDisplayRecords = filteredRedirects.Count();
            return displayedRedirects.ToList();
        }

    }
    public interface IRedirectRepository : IRepository<Redirect>
    {
        IEnumerable<Redirect> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
    }
}
