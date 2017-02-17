using CmsCore.Data.Infrastructure;
using CmsCore.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Data.Repositories
{
    public class WidgetRepository : RepositoryBase<Widget>, IWidgetRepository
    {

        public WidgetRepository(ApplicationDbContext dbContext)
                : base(dbContext) { }
        public IEnumerable<Widget> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');

            var query = this.DbContext.Widgets.Include(m=>m.Section).AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    query = query.Where(p => p.Id.ToString().Contains(sSearch) || p.Name.Contains(sSearch) );
                }
            }

            var allWidgets = query;
            IEnumerable<Widget> filteredWidgets = allWidgets;
            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredWidgets = filteredWidgets.OrderBy(p => p.Id);
                        break;
                    case 2:
                        filteredWidgets = filteredWidgets.OrderBy(p => p.Name);
                        break;
                    case 3:
                        filteredWidgets = filteredWidgets.OrderBy(p => p.Action);
                        break;
                    case 4:
                        filteredWidgets = filteredWidgets.OrderBy(p => p.Params);
                        break;
                    case 5:
                        filteredWidgets = filteredWidgets.OrderBy(p => p.Description);
                        break;
                    case 6:
                        filteredWidgets = filteredWidgets.OrderBy(p => p.IsTemplate);
                        break;
                    case 7:
                        filteredWidgets = filteredWidgets.OrderBy(p => p.Section.Name);
                        break;
                    default:
                        filteredWidgets = filteredWidgets.OrderBy(c => c.Id);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredWidgets = filteredWidgets.OrderByDescending(p => p.Id);
                        break;                                   
                    case 2:                                      
                        filteredWidgets = filteredWidgets.OrderByDescending(p => p.Name);
                        break;                                   
                    case 3:                                      
                        filteredWidgets = filteredWidgets.OrderByDescending(p => p.Action);
                        break;                                   
                    case 4:                                       
                        filteredWidgets = filteredWidgets.OrderByDescending(p => p.Params);
                        break;                                  
                    case 5:                                     
                        filteredWidgets = filteredWidgets.OrderByDescending(p => p.Description);
                        break;                                  
                    case 6:                                     
                        filteredWidgets = filteredWidgets.OrderByDescending(p => p.IsTemplate);
                        break;                                   
                    case 7:                                        
                        filteredWidgets = filteredWidgets.OrderByDescending(p => p.Section.Name);
                        break;                                  
                    default:                                       
                        filteredWidgets = filteredWidgets.OrderByDescending(c => c.Id);
                        break;
                }
            }
            var displayedWidgets = filteredWidgets.Skip(displayStart);
            if (displayLength > 0)
            {
                displayedWidgets = displayedWidgets.Take(displayLength);
            }
            totalRecords = allWidgets.Count();
            totalDisplayRecords = filteredWidgets.Count();
            return displayedWidgets.ToList();
        }

    }
    public interface IWidgetRepository : IRepository<Widget>
    {
        IEnumerable<Widget> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
    }
}
