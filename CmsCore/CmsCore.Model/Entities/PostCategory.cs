using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.Entities
{
    public class PostCategory:BaseEntity
    {
        public PostCategory()
        {
            PostPostCategories = new HashSet<PostPostCategory>();
            ChildCategories = new HashSet<PostCategory>();
            LanguageId = 1;
        }

        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }

        public long? ParentCategoryId { get; set; }
        public virtual PostCategory ParentCategory { get; set; }
        public virtual ICollection<PostCategory> ChildCategories { get; set; }

        public virtual ICollection<PostPostCategory> PostPostCategories { get; set; }
        public long LanguageId { get; set; }
        public virtual Language Language { get; set; }
        
    }
}
