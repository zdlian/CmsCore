using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.Entities
{
    public class Page:BaseEntity
    {
        public Page()
        {
            IsPublished = true;
            ViewCount = 0;
            ChildPages = new HashSet<Page>();
            LanguageId = 1;
            Translations = new HashSet<Page>();
        }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Body { get; set; }
        public long ViewCount { get; set; }

        public long? ParentPageId { get; set; }
        public virtual Page ParentPage { get; set; }
        public virtual ICollection<Page> ChildPages { get; set; }

        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }

        public bool IsPublished { get; set; }

        public long? TemplateId { get; set; }
        public virtual Template Template { get; set; }

        public long LanguageId { get; set; }
        public virtual Language Language { get; set; }
        public virtual ICollection<Page> Translations { get; set; }
    }
}
