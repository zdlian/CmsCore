using CmsCore.Data.Infrastructure;
using CmsCore.Data.Repositories;
using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Service
{
    public interface IProductCategoryService
    {
        IEnumerable<ProductCategory> GetParentProductCategories();
        IEnumerable<ProductCategory> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
        IEnumerable<ProductCategory> GetProductCategories();
        IEnumerable<ProductCategory> GetParentCategories();
        ProductCategory GetProductCategory(long id);
        ProductCategory GetProductCategoryBySlug(string slug);
        void CreateProductCategory(ProductCategory productCategory);
        void UpdateProductCategory(ProductCategory productCategory);
        void DeleteProductCategory(long id);
        void SaveProductCategory();
    }

    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository productCategoryRepository;
        private readonly IUnitOfWork unitOfWork;
        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IUnitOfWork unitOfWork)
        {
            this.productCategoryRepository = productCategoryRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IProductCategoryService Members
        public IEnumerable<ProductCategory> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            var productCategories = productCategoryRepository.Search(search, sortColumnIndex, sortDirection, displayStart, displayLength, out totalRecords, out totalDisplayRecords);
            return productCategories;
        }
        public IEnumerable<ProductCategory> GetProductCategories()
        {
            var productCategories = productCategoryRepository.GetAll("ChildCategories");
            return productCategories;

        }
        public IEnumerable<ProductCategory> GetParentProductCategories()
        {
            var productCategories = productCategoryRepository.GetMany(c => c.ParentCategoryId == null, "ChildCategories");
            return productCategories;
        }
        public ProductCategory GetProductCategory(long id)
        {
            var productCategory = productCategoryRepository.GetById(id);
            return productCategory;
        }
        public void CreateProductCategory(ProductCategory productCategory)
        {
            productCategoryRepository.Add(productCategory);
        }
        public void UpdateProductCategory(ProductCategory productCategory)
        {
            productCategoryRepository.Update(productCategory);
        }
        public void DeleteProductCategory(long id)
        {
            productCategoryRepository.Delete(pc => pc.Id == id);
        }
        public void SaveProductCategory()
        {
            unitOfWork.Commit();
        }
        public IEnumerable<ProductCategory> GetParentCategories()
        {
            var productCategory = productCategoryRepository.GetMany(s => s.ParentCategoryId == null);
            return productCategory;
        }
        public ProductCategory GetProductCategoryBySlug(string slug)
        {
            var productCategory = productCategoryRepository.GetBySlug(slug);
            return productCategory;
        }

        #endregion
    }
}
