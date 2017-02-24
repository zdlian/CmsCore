using CmsCore.Data.Infrastructure;
using CmsCore.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Data.Repositories
{
    public class LinkRepository : RepositoryBase<Link>, ILinkRepository
    {

        public LinkRepository(ApplicationDbContext dbContext)
                : base(dbContext) { }
        public IEnumerable<Link> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');

            var query = this.DbContext.Links.AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    query = query.Where(p => p.Id.ToString().Contains(sSearch) || p.Name.Contains(sSearch));
                }
            }

            var allLinks = query;
            IEnumerable<Link> filteredLinks = allLinks;
            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredLinks = filteredLinks.OrderBy(p => p.Id);
                        break;
                    case 2:
                        filteredLinks = filteredLinks.OrderBy(p => p.Name);
                        break;
                    case 3:
                        filteredLinks = filteredLinks.OrderBy(p => p.Url);
                        break;
                    case 4:
                        filteredLinks = filteredLinks.OrderBy(p => p.Description);
                        break;
                    case 5:
                        filteredLinks = filteredLinks.OrderBy(p => p.Target);
                        break;
                    default:
                        filteredLinks = filteredLinks.OrderBy(c => c.Id);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredLinks = filteredLinks.OrderByDescending(p => p.Id);
                        break;
                    case 2:
                        filteredLinks = filteredLinks.OrderByDescending(p => p.Name);
                        break;
                    case 3:
                        filteredLinks = filteredLinks.OrderByDescending(p => p.Url);
                        break;
                    case 4:
                        filteredLinks = filteredLinks.OrderByDescending(p => p.Description);
                        break;
                    case 5:
                        filteredLinks = filteredLinks.OrderByDescending(p => p.Target);
                        break;
                    default:
                        filteredLinks = filteredLinks.OrderByDescending(c => c.Id);
                        break;
                }
            }
            var displayedLinks = filteredLinks.Skip(displayStart);
            if (displayLength > 0)
            {
                displayedLinks = displayedLinks.Take(displayLength);
            }
            totalRecords = allLinks.Count();
            totalDisplayRecords = filteredLinks.Count();
            return displayedLinks.ToList();
        }

    }
    public interface ILinkRepository : IRepository<Link>
    {
        IEnumerable<Link> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
    }
}
