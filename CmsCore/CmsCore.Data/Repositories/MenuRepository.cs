using CmsCore.Data.Infrastructure;
using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Data.Repositories
{
    public class MenuRepository : RepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository(ApplicationDbContext dbContext)
                : base(dbContext) { }
        public IEnumerable<Menu> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');

            var query = this.DbContext.Menus.AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    //query = query.Where(p => p.Title.Contains(sSearch) || p.AddedBy.Contains(sSearch) || p.ViewCount.ToString().Contains(sSearch) || p.ModifiedDate.ToString().Contains(sSearch));
                }
            }

            var allMenus = query;



            IEnumerable<Menu> filteredMenus = allMenus;



            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 0:
                        filteredMenus = filteredMenus.OrderByDescending(p => p.Name);
                        break;
                    case 1:
                        filteredMenus = filteredMenus.OrderByDescending(p => p.AddedBy);
                        break;
                    case 2:
                        filteredMenus = filteredMenus.OrderByDescending(c => c.MenuLocation.Name);
                        break;
                    case 3:
                        filteredMenus = filteredMenus.OrderByDescending(c => c.ModifiedDate);
                        break;
                    default:
                        filteredMenus = filteredMenus.OrderByDescending(c => c.Name);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {
                    case 0:
                        filteredMenus = filteredMenus.OrderByDescending(p => p.Name);
                        break;
                    case 1:
                        filteredMenus = filteredMenus.OrderByDescending(p => p.AddedBy);
                        break;
                    case 2:
                        filteredMenus = filteredMenus.OrderByDescending(c => c.MenuLocation.Name);
                        break;
                    case 3:
                        filteredMenus = filteredMenus.OrderByDescending(c => c.ModifiedDate);
                        break;
                    default:
                        filteredMenus = filteredMenus.OrderByDescending(c => c.Name);
                        break;
                }
            }
            var displayedMenus = filteredMenus.Skip(displayStart);
            if (displayLength > 0)
            {
                displayedMenus = displayedMenus.Take(displayLength);
            }
            totalRecords = allMenus.Count();
            totalDisplayRecords = filteredMenus.Count();
            return displayedMenus.ToList();
        }

    }
    public interface IMenuRepository : IRepository<Menu>
    {
        IEnumerable<Menu> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
    }
}
