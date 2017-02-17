using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Admin.Models
{
    public class SectionViewModel:BaseEntity
    {
        
        public string Name { get; set; }

        public virtual ICollection<Widget> Widgets { get; set; }
        public virtual ICollection<TemplateSection> TemplateSections { get; set; }
    }
}
