using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.Entities
{
    public class Media:BaseEntity
    {
        public string Title { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public decimal Size { get; set; }
    }
}
