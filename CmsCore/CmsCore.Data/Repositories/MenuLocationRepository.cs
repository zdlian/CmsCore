using CmsCore.Data.Infrastructure;
using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Data.Repositories
{
    public class MenuLocationRepository : RepositoryBase<MenuLocation>, IMenuLocationRepository
    {
        public MenuLocationRepository(ApplicationDbContext dbContext)
                : base(dbContext) { }
        public IEnumerable<MenuLocation> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');

            var query = this.DbContext.MenuLocations.AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    //query = query.Where(p => p.Title.Contains(sSearch) || p.AddedBy.Contains(sSearch) || p.ViewCount.ToString().Contains(sSearch) || p.ModifiedDate.ToString().Contains(sSearch));
                }
            }

            var allMenuLocations = query;
            IEnumerable<MenuLocation> filteredMenuLocations = allMenuLocations;
            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredMenuLocations = filteredMenuLocations.OrderBy(p => p.Id);
                        break;
                    case 2:
                        filteredMenuLocations = filteredMenuLocations.OrderBy(p => p.Name);
                        break;
                    default:
                        filteredMenuLocations = filteredMenuLocations.OrderBy(c => c.Id);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredMenuLocations = filteredMenuLocations.OrderByDescending(p => p.Id);
                        break;
                    case 2:
                        filteredMenuLocations = filteredMenuLocations.OrderByDescending(p => p.Name);
                        break;
                    default:
                        filteredMenuLocations = filteredMenuLocations.OrderByDescending(c => c.Id);
                        break;
                }
            }
            var displayedMenuLocations = filteredMenuLocations.Skip(displayStart);
            if (displayLength > 0)
            {
                displayedMenuLocations = displayedMenuLocations.Take(displayLength);
            }
            totalRecords = allMenuLocations.Count();
            totalDisplayRecords = filteredMenuLocations.Count();
            return displayedMenuLocations.ToList();
        }

    }
    public interface IMenuLocationRepository : IRepository<MenuLocation>
    {
        IEnumerable<MenuLocation> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
    }
}
