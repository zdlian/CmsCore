using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Admin.Models
{
    public class SectionViewModel:BaseEntity
    {
        public SectionViewModel()
        {
            Widgets = new HashSet<Widget>();
            TemplateSections = new HashSet<TemplateSection>();
        }
        public string Name { get; set; }

        public virtual ICollection<Widget> Widgets { get; set; }
        public virtual ICollection<TemplateSection> TemplateSections { get; set; }
    }
}
