using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.Entities
{
    public class MenuLocation:BaseEntity
    {
        public string Name { get; set; }

        public int? MenuId { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
