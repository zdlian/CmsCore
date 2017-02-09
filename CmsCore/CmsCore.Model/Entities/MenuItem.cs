using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.Entities
{
    public class MenuItem:BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Target { get; set; }

        public int? ParentMenuItemId { get; set; }
        public virtual MenuItem ParentMenuItem { get; set; }

        public int MenuId { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
