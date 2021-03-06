﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.Entities
{
    public class Page:BaseEntity
    {
        public Page()
        {
            IsPublished = true;
        }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Body { get; set; }

        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }

        public bool IsPublished { get; set; }

        public int TemplateId { get; set; }
        public virtual Template Template { get; set; }
    }
}
