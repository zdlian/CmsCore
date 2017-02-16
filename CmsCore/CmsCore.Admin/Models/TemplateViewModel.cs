using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Admin.Models
{
    public class TemplateViewModel:BaseEntity
    {
        public TemplateViewModel()
        {
         
        }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string ViewName { get; set; }
       
    }
}
