using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.Entities
{
    public class SideBar:BaseEntity
    {
        public SideBar()
        {
            Widgets = new HashSet<Widget>();
        }
        public string Name { get; set; }

        public virtual ICollection<Widget> Widgets { get; set; }
    }
}
