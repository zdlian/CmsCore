using CmsCore.Data.Infrastructure;
using CmsCore.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Data.Repositories
{
    public class MenuItemRepository : RepositoryBase<MenuItem>, IMenuItemRepository
    {

        public MenuItemRepository(ApplicationDbContext dbContext)
                : base(dbContext) { }
        public IEnumerable<MenuItem> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');

            var query = this.DbContext.MenuItems.AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    query = query.Where(p => p.Id.ToString().Contains(sSearch) || p.Name.Contains(sSearch) );
                }
            }

            var allMenuItems = query;
            IEnumerable<MenuItem> filteredMenuItems = allMenuItems;
            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredMenuItems = filteredMenuItems.OrderBy(p => p.Id);
                        break;
                    case 2:
                        filteredMenuItems = filteredMenuItems.OrderBy(p => p.Name);
                        break;
                    case 3:
                        filteredMenuItems = filteredMenuItems.OrderBy(p => p.Url);
                        break;
                    case 4:
                        filteredMenuItems = filteredMenuItems.OrderBy(p => p.Target);
                        break;
                    default:
                        filteredMenuItems = filteredMenuItems.OrderBy(c => c.Id);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredMenuItems = filteredMenuItems.OrderByDescending(p => p.Id);
                        break;
                    case 2:
                        filteredMenuItems = filteredMenuItems.OrderByDescending(p => p.Name);
                        break;
                    case 3:
                        filteredMenuItems = filteredMenuItems.OrderByDescending(p => p.Url);
                        break;
                    case 4:
                        filteredMenuItems = filteredMenuItems.OrderByDescending(p => p.Target);
                        break;

                    default:
                        filteredMenuItems = filteredMenuItems.OrderByDescending(c => c.Id);
                        break;
                }
            }
            var displayedMenuItems = filteredMenuItems.Skip(displayStart);
            if (displayLength > 0)
            {
                displayedMenuItems = displayedMenuItems.Take(displayLength);
            }
            totalRecords = allMenuItems.Count();
            totalDisplayRecords = filteredMenuItems.Count();
            return displayedMenuItems.ToList();
        }

    }
    public interface IMenuItemRepository : IRepository<MenuItem>
    {
        IEnumerable<MenuItem> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
    }
}
