using CmsCore.Admin.Models;
using CmsCore.Model.Entities;
using CmsCore.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Admin.Controllers
{
    public class SettingController : BaseController
    {
        private readonly ISettingService settingService;
        public SettingController(ISettingService settingService)
        {
            this.settingService = settingService;
        }
        public IActionResult Index() {
            var settings = settingService.GetSettings();
            
            return View(settings);
        }
        [HttpPost]
        public IActionResult Index(SettingViewModel settingVM){
            var headerScript = settingService.GetSettingByName("HeaderScript");
            headerScript.Value = settingVM.HeaderScript;
            settingService.UpdateSetting(headerScript);

            var googleAnalytics = settingService.GetSettingByName("GoogleAnalytics");
            googleAnalytics.Value = settingVM.GoogleAnalytics;
            settingService.UpdateSetting(googleAnalytics);

            var footerScript = settingService.GetSettingByName("FooterScript");
            footerScript.Value = settingVM.FooterScript;
            settingService.UpdateSetting(footerScript);

            settingService.SaveSetting();
            return RedirectToAction("Index");
        }

    }
}

