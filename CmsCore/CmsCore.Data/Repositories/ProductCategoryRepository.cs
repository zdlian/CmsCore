using CmsCore.Data.Infrastructure;
using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Data.Repositories
{
    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(ApplicationDbContext dbContext)
            : base(dbContext) { }
        public ProductCategory GetBySlug(string slug)
        {
            slug = slug.ToLower();
            return Get(p => p.Slug == slug);
        }
        public IEnumerable<ProductCategory> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');
            var query = this.DbContext.ProductCategories.AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    query = query.Where(c => c.Id.ToString().Contains(sSearch) || c.Name.Contains(sSearch) || c.Slug.Contains(sSearch) || c.Description.Contains(sSearch));
                }
            }
            var allCategories = query;
            IEnumerable<ProductCategory> filteredCategories = allCategories;
            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredCategories = filteredCategories.OrderBy(c => c.Id);
                        break;
                    case 2:
                        filteredCategories = filteredCategories.OrderBy(c => c.Name);
                        break;
                    case 3:
                        filteredCategories = filteredCategories.OrderBy(c => c.Slug);
                        break;
                    case 4:
                        filteredCategories = filteredCategories.OrderBy(c => c.Description);
                        break;
                    default:
                        filteredCategories = filteredCategories.OrderBy(c => c.Id);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredCategories = filteredCategories.OrderByDescending(c => c.Id);
                        break;
                    case 2:
                        filteredCategories = filteredCategories.OrderByDescending(c => c.Name);
                        break;
                    case 3:
                        filteredCategories = filteredCategories.OrderByDescending(c => c.Slug);
                        break;
                    case 4:
                        filteredCategories = filteredCategories.OrderByDescending(c => c.Description);
                        break;
                    default:
                        filteredCategories = filteredCategories.OrderByDescending(c => c.Id);
                        break;
                }

            }
            var displayedCategories = filteredCategories.Skip(displayStart);
            if (displayLength >= 0)
            {
                displayedCategories = displayedCategories.Take(displayLength);
            }
            totalRecords = allCategories.Count();
            totalDisplayRecords = filteredCategories.Count();
            return displayedCategories.ToList();
        }


    }
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        ProductCategory GetBySlug(string slug);
        IEnumerable<ProductCategory> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);

    }
}

