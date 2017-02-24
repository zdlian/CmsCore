using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.Entities
{
    public class FeedbackValue:BaseEntity
    {
        public int? FormFieldId { get; set; }

        public string FormFieldName { get; set; }

        public virtual FieldType FieldType { get; set; }
        public int Position { get; set; }

        public string Value { get; set; }

        public int FeedbackId { get; set; }

        public virtual Feedback Feedback { get; set; }
    }
}
