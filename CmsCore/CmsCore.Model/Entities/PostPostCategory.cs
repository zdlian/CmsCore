using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.Entities
{
    public class PostPostCategory
    {
        public long PostId { get; set; }
        public virtual Post Post { get; set; }

        public long PostCategoryId { get; set; }
        public virtual PostCategory PostCategory { get; set; }
    }
}
