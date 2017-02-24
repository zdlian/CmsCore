using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.Entities
{
    public class LinkLinkCategory:BaseEntity
    {
        public long LinkId { get; set; }
        public virtual Link Link { get; set; }

        public long LinkCategoryId { get; set; }
        public virtual LinkCategory LinkCategory { get; set; }
    }
}
