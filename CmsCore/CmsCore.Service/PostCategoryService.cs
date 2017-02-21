using CmsCore.Data.Infrastructure;
using CmsCore.Data.Repositories;
using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Service
{
    public interface IPostCategoryService
    {
        IEnumerable<PostCategory> GetParentPostCategories();
        IEnumerable<PostCategory> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
        IEnumerable<PostCategory> GetPostCategories();
        IEnumerable<PostCategory> GetParentCategories();
        PostCategory GetPostCategory(long id);
        PostCategory GetPostCategoryBySlug(string slug);
        void CreatePostCategory(PostCategory postCategory);
        void UpdatePostCategory(PostCategory postCategory);
        void DeletePostCategory(long id);
        void SavePostCategory();
    }

    public class PostCategoryService:IPostCategoryService
    {
        private readonly IPostCategoryRepository postCategoryRepository;
        private readonly IUnitOfWork unitOfWork;
        public PostCategoryService(IPostCategoryRepository postCategoryRepository, IUnitOfWork unitOfWork)
        {
            this.postCategoryRepository = postCategoryRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IPostCategoryService Members
        public IEnumerable<PostCategory> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            var postCategories = postCategoryRepository.Search(search, sortColumnIndex, sortDirection, displayStart, displayLength, out totalRecords, out totalDisplayRecords);
            return postCategories;
        }
        public IEnumerable<PostCategory> GetPostCategories()
        {
            var postCategories = postCategoryRepository.GetAll("ChildCategories");
            return postCategories;

        }
        public IEnumerable<PostCategory> GetParentPostCategories()
        {
            var postCategories = postCategoryRepository.GetMany(c => c.ParentCategoryId == null, "ChildCategories");
            return postCategories;
        }
        public PostCategory GetPostCategory(long id)
        {
            var postCategory = postCategoryRepository.GetById(id);
            return postCategory;
        }
        public void CreatePostCategory(PostCategory postCategory)
        {
            postCategoryRepository.Add(postCategory);
        }
        public void UpdatePostCategory(PostCategory postCategory)
        {
            postCategoryRepository.Update(postCategory);
        }
        public void DeletePostCategory(long id)
        {
            postCategoryRepository.Delete(pc => pc.Id == id);
        }
        public void SavePostCategory()
        {
            unitOfWork.Commit();
        }
        public IEnumerable<PostCategory> GetParentCategories()
        {
            var postCategory = postCategoryRepository.GetMany(s => s.ParentCategoryId == null);
            return postCategory;
        }
        public PostCategory GetPostCategoryBySlug(string slug)
        {
            var postCategory = postCategoryRepository.GetBySlug(slug);
            return postCategory;
        }

        #endregion
    }
}
