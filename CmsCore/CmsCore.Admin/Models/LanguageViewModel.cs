using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Admin.Models
{
    public class LanguageViewModel:BaseEntity
    {
        public string Name { get; set; }
        public string NativeName { get; set; }
        public string Culture { get; set; }
    }
}
