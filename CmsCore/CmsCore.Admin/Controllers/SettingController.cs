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
            if (ModelState.IsValid){
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
            return RedirectToAction("Index");
        }
        public IActionResult Mail() {
            var settings = settingService.GetSettings();
            return View(settings);
        }
        [HttpPost]
        public IActionResult Mail(SettingViewModel settingVM) {
            if (ModelState.IsValid){
                var smtpUserName = settingService.GetSettingByName("SmtpUserName");
                 smtpUserName.Value = settingVM.SmtpUserName;
                 settingService.UpdateSetting(smtpUserName);
                
                 var smtpPassword = settingService.GetSettingByName("SmtpPassword");
                 smtpPassword.Value = settingVM.SmtpPassword;
                 settingService.UpdateSetting(smtpPassword);
                
                 var smtpHost = settingService.GetSettingByName("SmtpHost");
                 smtpHost.Value = settingVM.SmtpHost;
                 settingService.UpdateSetting(smtpHost);
                
                 var smtpUseSSL = settingService.GetSettingByName("SmtpUseSSL");
                 smtpUseSSL.Value = settingVM.SmtpUseSSL;
                 settingService.UpdateSetting(smtpUseSSL);
                
                 var smtpPort = settingService.GetSettingByName("SmtpPort");
                 smtpPort.Value = settingVM.SmtpPort;
                 settingService.UpdateSetting(smtpPort);
                
                 settingService.SaveSetting();
                 return RedirectToAction("Mail");
            }
            return RedirectToAction("Mail");
        }

    }
}

