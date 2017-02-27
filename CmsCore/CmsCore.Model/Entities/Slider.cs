using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.Entities
{
    public class Slider:BaseEntity
    {
        public Slider()
        {
            IsPublished = true;
            Slides = new HashSet<Slide>();
        }
        public string Name { get; set; }
        public bool IsPublished { get; set; }
        public virtual ICollection<Slide> Slides { get; set; }
    }
}
