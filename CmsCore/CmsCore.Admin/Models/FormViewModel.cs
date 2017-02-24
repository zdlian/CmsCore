using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Admin.Models
{
    public class FormViewModel:BaseEntity
    {
        public FormViewModel()
        {
            IsPublished = true;
            FormFields = new HashSet<FormField>();
        }
        public string FormName { get; set; }

        public string EmailTo { get; set; }

        public string EmailBcc { get; set; }

        public string EmailCc { get; set; }

        public string Description { get; set; }

        public string ClosingDescription { get; set; }

        public string GoogleAnalyticsCode { get; set; }

        public virtual ICollection<FormField> FormFields { get; set; }

        public bool IsPublished { get; set; }
    }
}
