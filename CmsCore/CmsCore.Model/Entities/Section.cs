using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.Entities
{
    public class Section:BaseEntity
    {
        public Section()
        {
            Widgets = new HashSet<Widget>();
            TemplateSections = new HashSet<TemplateSection>();
        }
        public string Name { get; set; }

        public virtual ICollection<Widget> Widgets { get; set; }
        public virtual ICollection<TemplateSection> TemplateSections { get; set; }
    }
}
