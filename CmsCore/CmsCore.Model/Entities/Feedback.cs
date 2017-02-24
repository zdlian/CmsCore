using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.Entities
{
    public class Feedback:BaseEntity
    {
        public Feedback()
        {
            FeedbackValues = new HashSet<FeedbackValue>();
        }
        public string UserName { get; set; }

        public DateTime SentDate { get; set; }

        public int? FormId { get; set; }

        public string FormName { get; set; }

        public string IP { get; set; }

        public virtual ICollection<FeedbackValue> FeedbackValues { get; set; }
    }
}
