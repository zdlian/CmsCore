using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Web.Models
{
    public class PageViewModel : BaseEntity
    {
        public PageViewModel()
        {
            IsPublished = true;
            ViewCount = 0;
            ChildPages = new HashSet<PageViewModel>();
        }
        
        public string Title { get; set; }
      
        public string Slug { get; set; }
        public string Body { get; set; }
        public long ViewCount { get; set; }

        public long? ParentPageId { get; set; }
        public PageViewModel ParentPage { get; set; }
        public virtual ICollection<PageViewModel> ChildPages { get; set; }

        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }

        public bool IsPublished { get; set; }

        public long? TemplateId { get; set; }
        public virtual Template Template { get; set; }

        public long LanguageId { get; set; }
        public virtual Language Language { get; set; }
    }
}
