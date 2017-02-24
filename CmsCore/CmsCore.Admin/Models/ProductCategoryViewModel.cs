using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Admin.Models
{
    public class ProductCategoryViewModel:BaseEntity
    {
        public ProductCategoryViewModel()
        {
            ProductProductCategories = new HashSet<ProductProductCategory>();
            ChildCategories = new HashSet<ProductCategory>();
        }

        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }

        public long? ParentCategoryId { get; set; }
        public virtual ProductCategory ParentCategory { get; set; }
        public virtual ICollection<ProductCategory> ChildCategories { get; set; }

        public virtual ICollection<ProductProductCategory> ProductProductCategories { get; set; }
    }
}
