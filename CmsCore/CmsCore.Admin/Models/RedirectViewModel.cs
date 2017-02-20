using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Admin.Models
{
    public class RedirectViewModel:BaseEntity
    {
        public RedirectViewModel()
        {
            IsActive = true;
        }
        public string Name { get; set; }
        public string OldUrl { get; set; }
        public string NewUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
