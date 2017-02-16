using CmsCore.Data.Infrastructure;
using CmsCore.Data.Repositories;
using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Service
{
    public interface IPageService
    {
        IEnumerable<Page> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
        IEnumerable<Page> GetPages();
        Page GetPage(long id);
        Page GetPageBySlug(string slug);
        void CreatePage(Page page);
        void UpdatePage(Page page);
        void DeletePage(long id);
        void SavePage();
    }

    public class PageService : IPageService
    {
        private readonly IPageRepository pagesRepository;
        private readonly IUnitOfWork unitOfWork;

        public PageService(IPageRepository pageRepository, IUnitOfWork unitOfWork)
        {
            this.pagesRepository = pageRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IPageService Members

        public IEnumerable<Page> GetPages()
        {
            var pages = pagesRepository.GetAll();
            return pages;
        }

  
        public Page GetPage(long id)
        {
            var page = pagesRepository.GetById(id, "ParentPage", "Template");
            return page;
        }

        public Page GetPageBySlug(string slug)
        {
            var page = pagesRepository.GetBySlug(slug);
            return page;
        }

        public void CreatePage(Page page)
        {
            pagesRepository.Add(page);
        }

        public void UpdatePage(Page page)
        {
            pagesRepository.Update(page);
        }

        public void DeletePage(long id)
        {
            pagesRepository.Delete(p => p.Id == id);
        }

        public void SavePage()
        {
            unitOfWork.Commit();
        }

        public IEnumerable<Page> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            var pages = pagesRepository.Search(search, sortColumnIndex, sortDirection, displayStart, displayLength, out totalRecords, out totalDisplayRecords);
            return pages;
        }

        #endregion

    }
}
