using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.Entities
{
    public class Product:BaseEntity
    {
        public Product()
        {
            IsPublished = true;
            ViewCount = 0;
            ChildProducts = new HashSet<Product>();
        }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Body { get; set; }

        public long? ParentProductId { get; set; }
        public Product ParentProduct { get; set; }
        public virtual ICollection<Product> ChildProducts { get; set; }

        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }

        public bool IsPublished { get; set; }
        public long ViewCount { get; set; }
    }
}
