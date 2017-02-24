using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Admin.Models
{
    public class FormFieldViewModel:BaseEntity
    {
        public string Name { get; set; }
        public bool Required { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public virtual FieldType FieldType { get; set; }

        public int? FormId { get; set; }
        public virtual Form Form { get; set; }
    }
}
