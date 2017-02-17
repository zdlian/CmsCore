using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.Entities
{
    public class TemplateSection
    {
        public long TemplateId { get; set; }
        public virtual Template Template { get; set; }

        public long SectionId { get; set; }
        public virtual Section Section { get; set; }
    }
}
