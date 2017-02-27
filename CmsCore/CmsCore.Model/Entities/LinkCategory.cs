using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.Entities
{
    public class LinkCategory:BaseEntity
    {
        public LinkCategory()
        {
            LinkLinkCategories = new HashSet<LinkLinkCategory>();
            LanguageId = 1;
            ChildCategories = new HashSet<LinkCategory>();
        }

        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }

        public long? ParentCategoryId { get; set; }
        public virtual LinkCategory ParentCategory { get; set; }
        public virtual ICollection<LinkCategory> ChildCategories { get; set; }

        public virtual ICollection<LinkLinkCategory> LinkLinkCategories { get; set; }
        public long LanguageId { get; set; }
        public virtual Language Language { get; set; }
        
    }
}
