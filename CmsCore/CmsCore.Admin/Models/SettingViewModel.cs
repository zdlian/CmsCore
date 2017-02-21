using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Admin.Models
{
    public class SettingViewModel:BaseEntity
    {
        public string HeaderScript { get; set; }
        public string GoogleAnalytics { get; set; }
        public string FooterScript { get; set; }
    }
}
