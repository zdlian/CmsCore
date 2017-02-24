using CmsCore.Data.Infrastructure;
using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Data.Repositories
{
    public class FormRepository : RepositoryBase<Form>, IFormRepository
    {
        public FormRepository(ApplicationDbContext dbContext)
            : base(dbContext) { }
        public IEnumerable<Form> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');


            var query = this.DbContext.Forms.AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {

                    query = query.Where(c => c.FormName.Contains(sSearch) || c.Id.ToString().Contains(sSearch));
                }
            }
            var allForms = query;

            IEnumerable<Form> filteredForms = allForms;





            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredForms = filteredForms.OrderBy(c => c.Id);
                        break;
                    case 2:
                        filteredForms = filteredForms.OrderBy(c => c.FormName);
                        break;
                    default:
                        filteredForms = filteredForms.OrderBy(c => c.Id);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {

                    case 1:
                        filteredForms = filteredForms.OrderByDescending(c => c.Id);
                        break;
                    case 2:
                        filteredForms = filteredForms.OrderByDescending(c => c.FormName);
                        break;
                    default:
                        filteredForms = filteredForms.OrderByDescending(c => c.Id);
                        break;
                }
            }

            var displayedForms = filteredForms.Skip(displayStart);
            if (displayLength > 0)
            {
                displayedForms = displayedForms.Take(displayLength);
            }
            totalRecords = allForms.Count();
            totalDisplayRecords = filteredForms.Count();
            return displayedForms.ToList();
        }
    }
    public interface IFormRepository : IRepository<Form>
    {
        IEnumerable<Form> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
    }
}
