using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Admin.Models
{
    public class ProductViewModel:BaseEntity
    {
        public ProductViewModel()
        {
            IsPublished = true;
            IsNew = false;
            IsAvailable = true;
            ViewCount = 0;
            ChildProducts = new HashSet<Product>();
            ProductProductCategories = new HashSet<ProductProductCategory>();
        }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Code { get; set; }
        public string Photo { get; set; }
        public string Body { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }

        public long? ParentProductId { get; set; }
        public virtual Product ParentProduct { get; set; }
        public virtual ICollection<Product> ChildProducts { get; set; }

        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }

        public bool IsAvailable { get; set; }
        public bool IsNew { get; set; }
        public bool IsPublished { get; set; }
        public long ViewCount { get; set; }
        public virtual ICollection<ProductProductCategory> ProductProductCategories { get; set; }
    }
}
