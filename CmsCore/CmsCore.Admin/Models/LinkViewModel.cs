using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Admin.Models
{
    public class LinkViewModel:BaseEntity
    {
        public LinkViewModel()
        {
            IsVisible = true;
            LinkLinkCategories = new HashSet<LinkLinkCategory>();
        }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Url { get; set; }
        public bool IsVisible { get; set; }
        public string Description { get; set; }
        public string Target { get; set; }
        public virtual ICollection<LinkLinkCategory> LinkLinkCategories { get; set; }
    }
}
