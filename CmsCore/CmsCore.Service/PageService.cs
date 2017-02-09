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
        IEnumerable<Page> GetPages();
        Page GetPage(long id);
        Page GetPageBySlug(string slug);
        void CreatePage(Page page);
        void SavePage();
    }

    public class PageService : IPageService
    {
        private readonly IPageRepository pagesRepository;
        private readonly IUnitOfWork unitOfWork;

        public PageService(IPageRepository pagesRepository, IUnitOfWork unitOfWork)
        {
            this.pagesRepository = pagesRepository;
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
            var page = pagesRepository.GetById(id);
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

        public void SavePage()
        {
            unitOfWork.Commit();
        }

        #endregion

    }
}
