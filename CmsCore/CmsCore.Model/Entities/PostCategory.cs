using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.Entities
{
    public class PostCategory
    {
        public long PostId { get; set; }
        public virtual Post Post { get; set; }

        public long CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
