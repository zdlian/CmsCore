using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.Entities
{
    public class Link:BaseEntity
    {
        public Link()
        {
            IsVisible = true;
            LinkLinkCategories = new HashSet<LinkLinkCategory>();
            LanguageId = 1;
            Translations = new HashSet<Link>();
        }

        public string Name { get; set; }
        public string Url { get; set; }
        public bool IsVisible { get; set; }
        public string Description { get; set; }
        public string Target { get; set; }
        public virtual ICollection<LinkLinkCategory> LinkLinkCategories { get; set; }
        public long LanguageId { get; set; }
        public virtual Language Language { get; set; }
        public virtual ICollection<Link> Translations { get; set; }
    }
}
