using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.Entities
{
    public class TemplateSideBar
    {
        public long TemplateId { get; set; }
        public virtual Template Template { get; set; }

        public long SideBarId { get; set; }
        public virtual SideBar SideBar { get; set; }
    }
}
