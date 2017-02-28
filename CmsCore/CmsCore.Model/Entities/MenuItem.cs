using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.Entities
{
    public class MenuItem:BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Target { get; set; }
        public long? ParentMenuItemId { get; set; }
        public virtual MenuItem ParentMenuItem { get; set; }
        public ICollection<MenuItem> ChildMenuItems { get; set; }
        public long? MenuId { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
