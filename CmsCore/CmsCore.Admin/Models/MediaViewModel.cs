using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Admin.Models
{
    public class MediaViewModel:BaseEntity
    {
        [Required]
        public string Title { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public decimal Size { get; set; }
    }
}
