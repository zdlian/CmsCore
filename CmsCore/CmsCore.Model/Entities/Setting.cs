using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.Entities
{
    public class Setting:BaseEntity
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
