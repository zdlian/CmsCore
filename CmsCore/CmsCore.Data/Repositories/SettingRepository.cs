using CmsCore.Data.Infrastructure;
using CmsCore.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Data.Repositories
{
    public class SettingRepository : RepositoryBase<Setting>, ISettingRepository
    {

        public SettingRepository(ApplicationDbContext dbContext)
                : base(dbContext) { }
        public Setting GetSettingByName(string name) { return DbContext.Settings.FirstOrDefault(s=>s.Name==name); }
        public IEnumerable<Setting> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');

            var query = this.DbContext.Settings.AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    query = query.Where(p => p.Id.ToString().Contains(sSearch) || p.Name.Contains(sSearch));
                }
            }

            var allSettings = query;
            IEnumerable<Setting> filteredSettings = allSettings;
            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredSettings = filteredSettings.OrderBy(p => p.Id);
                        break;
                    case 2:
                        filteredSettings = filteredSettings.OrderBy(p => p.Name);
                        break;
                    case 3:
                        filteredSettings = filteredSettings.OrderBy(p => p.Value);
                        break;


                    default:
                        filteredSettings = filteredSettings.OrderBy(c => c.Id);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredSettings = filteredSettings.OrderByDescending(p => p.Id);
                        break;
                    case 2:
                        filteredSettings = filteredSettings.OrderByDescending(p => p.Name);
                        break;
                    case 3:
                        filteredSettings = filteredSettings.OrderByDescending(p => p.Value);
                        break;
                    default:
                        filteredSettings = filteredSettings.OrderByDescending(c => c.Id);
                        break;
                }
            }
            var displayedSettings = filteredSettings.Skip(displayStart);
            if (displayLength > 0)
            {
                displayedSettings = displayedSettings.Take(displayLength);
            }
            totalRecords = allSettings.Count();
            totalDisplayRecords = filteredSettings.Count();
            return displayedSettings.ToList();
        }

    }
    public interface ISettingRepository : IRepository<Setting>
    {
        IEnumerable<Setting> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
        Setting GetSettingByName(string name);
    }
}
