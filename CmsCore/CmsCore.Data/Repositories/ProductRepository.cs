using CmsCore.Data.Infrastructure;
using CmsCore.Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CmsCore.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {

        public ProductRepository(ApplicationDbContext dbContext)
                : base(dbContext) { }
        public IEnumerable<Product> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');

            var query = this.DbContext.Products.AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    query = query.Where(p => p.Id.ToString().Contains(sSearch) || p.Title.Contains(sSearch));
                }
            }

            var allProducts = query;
            IEnumerable<Product> filteredProducts = allProducts;
            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredProducts = filteredProducts.OrderBy(p => p.Id);
                        break;
                    case 2:
                        filteredProducts = filteredProducts.OrderBy(p => p.Title);
                        break;
                    case 3:
                        filteredProducts = filteredProducts.OrderBy(p => p.Slug);
                        break;
                    case 4:
                        filteredProducts = filteredProducts.OrderBy(p => p.Code);
                        break;
                    case 5:
                        filteredProducts = filteredProducts.OrderBy(p => p.Photo);
                        break;
                    case 6:
                        filteredProducts = filteredProducts.OrderBy(p => p.Body);
                        break;
                    case 7:
                        filteredProducts = filteredProducts.OrderBy(p => p.Price);
                        break;
                    case 8:
                        filteredProducts = filteredProducts.OrderBy(p => p.OldPrice);
                        break;
                    default:
                        filteredProducts = filteredProducts.OrderBy(c => c.Id);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredProducts = filteredProducts.OrderByDescending(p => p.Id);
                        break;
                    case 2:
                        filteredProducts = filteredProducts.OrderByDescending(p => p.Title);
                        break;
                    case 3:
                        filteredProducts = filteredProducts.OrderByDescending(p => p.Slug);
                        break;
                    case 4:
                        filteredProducts = filteredProducts.OrderByDescending(p => p.Code);
                        break;
                    case 5:
                        filteredProducts = filteredProducts.OrderByDescending(p => p.Photo);
                        break;
                    case 6:
                        filteredProducts = filteredProducts.OrderByDescending(p => p.Body);
                        break;
                    case 7:
                        filteredProducts = filteredProducts.OrderByDescending(p => p.Price);
                        break;
                    case 8:
                        filteredProducts = filteredProducts.OrderByDescending(p => p.OldPrice);
                        break;
                    default:
                        filteredProducts = filteredProducts.OrderByDescending(c => c.Id);
                        break;
                }
            }
            var displayedProducts = filteredProducts.Skip(displayStart);
            if (displayLength > 0)
            {
                displayedProducts = displayedProducts.Take(displayLength);
            }
            totalRecords = allProducts.Count();
            totalDisplayRecords = filteredProducts.Count();
            return displayedProducts.ToList();
        }

    }
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
    }
}
