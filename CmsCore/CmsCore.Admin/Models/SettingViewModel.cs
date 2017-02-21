using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Admin.Models
{
    public class SettingViewModel:BaseEntity
    {
        //INDEX
        public string HeaderScript { get; set; }
        public string GoogleAnalytics { get; set; }
        public string FooterScript { get; set; }
        //MAIL
        public string SmtpUserName { get; set; }
        public string SmtpPassword { get; set; }
        public string SmtpHost { get; set; }
        public string SmtpPort { get; set; }
        public string SmtpUseSSL { get; set; }
        
    }
}
