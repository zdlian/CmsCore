using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.Entities
{
    public class Redirect:BaseEntity
    {
        public Redirect()
        {
            IsActive = true;
        }
     
        public string OldUrl { get; set; }
        public string NewUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
