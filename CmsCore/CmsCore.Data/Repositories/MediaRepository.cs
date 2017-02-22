using CmsCore.Data.Infrastructure;
using CmsCore.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Data.Repositories
{
    public class MediaRepository : RepositoryBase<Media>, IMediaRepository
    {

        public MediaRepository(ApplicationDbContext dbContext)
                : base(dbContext) { }
        public IEnumerable<Media> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');

            var query = this.DbContext.Medias.AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    query = query.Where(p => p.Id.ToString().Contains(sSearch) || p.Title.Contains(sSearch));
                }
            }

            var allMedias = query;
            IEnumerable<Media> filteredMedias = allMedias;
            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredMedias = filteredMedias.OrderBy(p => p.Id);
                        break;
                    case 2:
                        filteredMedias = filteredMedias.OrderBy(p => p.Title);
                        break;
                    case 3:
                        filteredMedias = filteredMedias.OrderBy(p => p.AddedBy);
                        break;
                    case 4:
                        filteredMedias = filteredMedias.OrderBy(p => p.AddedDate);
                        break;
                   
                    default:
                        filteredMedias = filteredMedias.OrderBy(c => c.Id);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredMedias = filteredMedias.OrderByDescending(p => p.Id);
                        break;
                    case 2:
                        filteredMedias = filteredMedias.OrderByDescending(p => p.Title);
                        break;
                    case 3:
                        filteredMedias = filteredMedias.OrderByDescending(p => p.AddedBy);
                        break;
                    case 4:
                        filteredMedias = filteredMedias.OrderByDescending(p => p.AddedDate);
                        break;
                   
                    default:
                        filteredMedias = filteredMedias.OrderByDescending(c => c.Id);
                        break;
                }
            }
            var displayedMedias = filteredMedias.Skip(displayStart);
            if (displayLength > 0)
            {
                displayedMedias = displayedMedias.Take(displayLength);
            }
            totalRecords = allMedias.Count();
            totalDisplayRecords = filteredMedias.Count();
            return displayedMedias.ToList();
        }

    }
    public interface IMediaRepository : IRepository<Media>
    {
        IEnumerable<Media> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
    }
}
