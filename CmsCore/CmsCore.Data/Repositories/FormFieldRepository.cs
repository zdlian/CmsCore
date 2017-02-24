using CmsCore.Data.Infrastructure;
using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Data.Repositories
{
    public class FormFieldRepository : RepositoryBase<FormField>, IFormFieldRepository
    {
        public FormFieldRepository(ApplicationDbContext dbContext)
            : base(dbContext) { }
        public IEnumerable<FormField> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');


            var query = this.DbContext.FormFields.AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    query = query.Where(c => c.Name.Contains(sSearch) || c.FieldType.ToString().Contains(sSearch) || c.Required.ToString().Contains(sSearch) || c.Form.FormName.Contains(sSearch));
                }
            }
            var allFormFields = query;

            IEnumerable<FormField> filteredFormFields = allFormFields;





            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredFormFields = filteredFormFields.OrderBy(c => c.Name);
                        break;
                    case 2:
                        filteredFormFields = filteredFormFields.OrderBy(c => c.FieldType.ToString());
                        break;
                    case 3:
                        filteredFormFields = filteredFormFields.OrderBy(c => c.Required);
                        break;
                    case 4:
                        filteredFormFields = filteredFormFields.OrderBy(c => c.Form.FormName);
                        break;
                    default:
                        filteredFormFields = filteredFormFields.OrderBy(c => c.Name);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {

                    case 1:
                        filteredFormFields = filteredFormFields.OrderByDescending(c => c.Name);
                        break;
                    case 2:
                        filteredFormFields = filteredFormFields.OrderByDescending(c => c.FieldType.ToString());
                        break;
                    case 3:
                        filteredFormFields = filteredFormFields.OrderByDescending(c => c.Required);
                        break;
                    case 4:
                        filteredFormFields = filteredFormFields.OrderByDescending(c => c.Form.FormName);
                        break;
                    default:
                        filteredFormFields = filteredFormFields.OrderByDescending(c => c.Name);
                        break;
                }
            }

            var displayedFormFields = filteredFormFields.Skip(displayStart);
            if (displayLength > 0)
            {
                displayedFormFields = displayedFormFields.Take(displayLength);
            }
            totalRecords = allFormFields.Count();
            totalDisplayRecords = filteredFormFields.Count();
            return displayedFormFields.ToList();
        }
        
    }
    public interface IFormFieldRepository : IRepository<FormField>
    {
        IEnumerable<FormField> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
    }
}
