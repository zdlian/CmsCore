using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.Entities
{
    public class Widget:BaseEntity
    {
        public string Name { get; set; }
        public string Action { get; set; }
        public string Params { get; set; }
        public string Description { get; set; }
        public bool IsTemplate { get; set; }
        public int? SideBarId { get; set; }
        public virtual Section SideBar { get; set; }
    }
}
