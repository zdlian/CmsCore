using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.Entities
{
    public class ProductProductCategory
    {
        public long ProductId { get; set; }
        public virtual Product Product { get; set; }

        public long ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
    }
}
