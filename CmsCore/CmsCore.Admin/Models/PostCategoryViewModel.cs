using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Admin.Models
{
    public class PostCategoryViewModel:BaseEntity
    {
        public PostCategoryViewModel()
        {
            PostPostCategories = new HashSet<PostPostCategory>();
            ChildCategories = new HashSet<PostCategory>();
        }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Slug { get; set; }
        public string Description { get; set; }

        public long? ParentCategoryId { get; set; }
        public virtual PostCategory ParentCategory { get; set; }
        public virtual ICollection<PostCategory> ChildCategories { get; set; }

        public virtual ICollection<PostPostCategory> PostPostCategories { get; set; }
    }
}
