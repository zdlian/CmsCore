using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.Entities
{
    public class Template:BaseEntity
    {
        public Template()
        {
            TemplateSideBars = new HashSet<TemplateSideBar>();
            Pages = new HashSet<Page>();
        }
       
        public string Name { get; set; }
        public string ViewName { get; set; }
        public virtual ICollection<TemplateSideBar> TemplateSideBars { get; set; }
        public virtual ICollection<Page> Pages { get; set; }
    }
}
