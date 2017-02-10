using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CmsCore.Admin.Models;
using Microsoft.AspNetCore.Mvc.Filters;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CmsCore.Admin.Controllers
{
    public class BaseController : Controller
    {
       
        protected readonly string AssetsUrl;
        protected readonly string UploadPath;
        
        public BaseController(AppSettings appSettings)
        {
            this.AssetsUrl = appSettings.AssetsUrl;
            this.UploadPath = appSettings.UploadPath;

          
        }   
        
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.AssetsUrl = this.AssetsUrl;
            ViewBag.UploadPath = this.UploadPath;
            base.OnActionExecuting(filterContext);
        }
    }
}
