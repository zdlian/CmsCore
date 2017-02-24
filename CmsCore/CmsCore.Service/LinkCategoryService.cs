using CmsCore.Data.Infrastructure;
using CmsCore.Data.Repositories;
using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Service
{
    public interface ILinkCategoryService
    {
        IEnumerable<LinkCategory> GetParentLinkCategories();
        IEnumerable<LinkCategory> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
        IEnumerable<LinkCategory> GetLinkCategories();
        IEnumerable<LinkCategory> GetParentCategories();
        LinkCategory GetLinkCategory(long id);
        LinkCategory GetLinkCategoryBySlug(string slug);
        void CreateLinkCategory(LinkCategory linkCategory);
        void UpdateLinkCategory(LinkCategory linkCategory);
        void DeleteLinkCategory(long id);
        void SaveLinkCategory();
    }

    public class LinkCategoryService : ILinkCategoryService
    {
        private readonly ILinkCategoryRepository linkCategoryRepository;
        private readonly IUnitOfWork unitOfWork;
        public LinkCategoryService(ILinkCategoryRepository linkCategoryRepository, IUnitOfWork unitOfWork)
        {
            this.linkCategoryRepository = linkCategoryRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ILinkCategoryService Members
        public IEnumerable<LinkCategory> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            var productCategories = linkCategoryRepository.Search(search, sortColumnIndex, sortDirection, displayStart, displayLength, out totalRecords, out totalDisplayRecords);
            return productCategories;
        }
        public IEnumerable<LinkCategory> GetLinkCategories()
        {
            var productCategories = linkCategoryRepository.GetAll("ChildCategories");
            return productCategories;

        }
        public IEnumerable<LinkCategory> GetParentLinkCategories()
        {
            var productCategories = linkCategoryRepository.GetMany(c => c.ParentCategoryId == null, "ChildCategories");
            return productCategories;
        }
        public LinkCategory GetLinkCategory(long id)
        {
            var linkCategory = linkCategoryRepository.GetById(id);
            return linkCategory;
        }
        public void CreateLinkCategory(LinkCategory linkCategory)
        {
            linkCategoryRepository.Add(linkCategory);
        }
        public void UpdateLinkCategory(LinkCategory linkCategory)
        {
            linkCategoryRepository.Update(linkCategory);
        }
        public void DeleteLinkCategory(long id)
        {
            linkCategoryRepository.Delete(pc => pc.Id == id);
        }
        public void SaveLinkCategory()
        {
            unitOfWork.Commit();
        }
        public IEnumerable<LinkCategory> GetParentCategories()
        {
            var linkCategory = linkCategoryRepository.GetMany(s => s.ParentCategoryId == null);
            return linkCategory;
        }
        public LinkCategory GetLinkCategoryBySlug(string slug)
        {
            var linkCategory = linkCategoryRepository.GetBySlug(slug);
            return linkCategory;
        }

        #endregion
    }
}
