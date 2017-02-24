using CmsCore.Data.Infrastructure;
using CmsCore.Data.Repositories;
using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Service
{
    public interface ILinkService
    {
        IEnumerable<Link> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
        IEnumerable<Link> GetLinks();
        Link GetLink(long id);
        void CreateLink(Link link);
        void UpdateLink(Link link);
        void DeleteLink(long id);
        void SaveLink();

    }

    public class LinkService : ILinkService
    {
        private readonly ILinkRepository linkRepository;
        private readonly IUnitOfWork unitOfWork;
        public LinkService(ILinkRepository linkRepository, IUnitOfWork unitOfWork)
        {
            this.linkRepository = linkRepository;
            this.unitOfWork = unitOfWork;
        }
        #region ILinkServiceMembers
        public IEnumerable<Link> GetLinks()
        {
            var links = linkRepository.GetAll();
            return links;
        }
        public Link GetLink(long id)
        {
            var link = linkRepository.GetById(id);
            return link;
        }
        public void CreateLink(Link link)
        {
            linkRepository.Add(link);
        }
        public void UpdateLink(Link link)
        {
            linkRepository.Update(link);
        }
        public void DeleteLink(long id)
        {
            linkRepository.Delete(x => x.Id == id);
        }
        public void SaveLink()
        {
            unitOfWork.Commit();
        }
        public IEnumerable<Link> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            var links = linkRepository.Search(search, sortColumnIndex, sortDirection, displayStart, displayLength, out totalRecords, out totalDisplayRecords);
            return links;
        }
    }
}
#endregion