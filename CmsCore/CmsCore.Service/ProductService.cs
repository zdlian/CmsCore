using CmsCore.Data.Infrastructure;
using CmsCore.Data.Repositories;
using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Service
{
    public interface IProductService
    {
        IEnumerable<Product> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
        IEnumerable<Product> GetProducts();
        Product GetProduct(long id);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(long id);
        void SaveProduct();

    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IUnitOfWork unitOfWork;
        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }
        #region IProductServiceMembers
        public IEnumerable<Product> GetProducts()
        {
            var products = productRepository.GetAll();
            return products;
        }
        public Product GetProduct(long id)
        {
            var product = productRepository.GetById(id);
            return product;
        }
        public void CreateProduct(Product product)
        {
            productRepository.Add(product);
        }
        public void UpdateProduct(Product product)
        {
            productRepository.Update(product);
        }
        public void DeleteProduct(long id)
        {
            productRepository.Delete(x => x.Id == id);
        }
        public void SaveProduct()
        {
            unitOfWork.Commit();
        }
        public IEnumerable<Product> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            var products = productRepository.Search(search, sortColumnIndex, sortDirection, displayStart, displayLength, out totalRecords, out totalDisplayRecords);
            return products;
        }
    }
}
#endregion