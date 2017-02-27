using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.Entities
{
    public class Language:BaseEntity
    {
        public Language()
        {
            IsActive = true;
            Pages = new HashSet<Page>();
            Posts = new HashSet<Post>();
            PostCategories = new HashSet<PostCategory>();
            Products = new HashSet<Product>();
            ProductCategories = new HashSet<ProductCategory>();
            Links = new HashSet<Link>();
            LinkCategories = new HashSet<LinkCategory>();
            Menus = new HashSet<Menu>();
            Forms = new HashSet<Form>();
        }
        public string Name { get; set; }
        public string NativeName { get; set; }
        public string Culture { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Page> Pages { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<PostCategory> PostCategories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
        public virtual ICollection<Link> Links { get; set; }
        public virtual ICollection<LinkCategory> LinkCategories { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<Form> Forms { get; set; }
    }
}
