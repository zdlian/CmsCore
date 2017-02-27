using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.Entities
{
    public class ProductCategory:BaseEntity
    {
        public ProductCategory()
        {
            ProductProductCategories = new HashSet<ProductProductCategory>();
            ChildCategories = new HashSet<ProductCategory>();
            LanguageId = 1;
        }

        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }

        public long? ParentCategoryId { get; set; }
        public virtual ProductCategory ParentCategory { get; set; }
        public virtual ICollection<ProductCategory> ChildCategories { get; set; }

        public virtual ICollection<ProductProductCategory> ProductProductCategories { get; set; }
        public long LanguageId { get; set; }
        public virtual Language Language { get; set; }
        
    }
}
