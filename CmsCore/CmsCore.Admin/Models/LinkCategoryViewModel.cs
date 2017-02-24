using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Admin.Models
{
    public class LinkCategoryViewModel:BaseEntity
    {
        public LinkCategoryViewModel()
        {
            LinkLinkCategories = new HashSet<LinkLinkCategory>();
            ChildCategories = new HashSet<LinkCategory>();
        }

        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }

        public long? ParentCategoryId { get; set; }
        public virtual LinkCategory ParentCategory { get; set; }
        public virtual ICollection<LinkCategory> ChildCategories { get; set; }

        public virtual ICollection<LinkLinkCategory> LinkLinkCategories { get; set; }
    }
}
