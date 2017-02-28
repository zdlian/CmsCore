using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.Entities
{
    public class Menu:BaseEntity
    {
        public Menu()
        {
            MenuItems = new HashSet<MenuItem>();
            LanguageId = 1;
        }
        public string Name { get; set; }
        public long? MenuLocationId { get; set; }
        public virtual MenuLocation MenuLocation { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }
        public long LanguageId { get; set; }
        public virtual Language Language { get; set; }
        
    }
}
