using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CmsCore.Admin.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CmsCore.Admin.Controllers
{
    public class BaseController : Controller
    {
       
        protected string AssetsUrl;
        protected string UploadPath;
      

        public BaseController()
        {
            
        }   
        
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {   var appSettings = (IOptions<AppSettings>)this.HttpContext.RequestServices.GetService(typeof(IOptions<AppSettings>));
            this.AssetsUrl = appSettings.Value.AssetsUrl;
            this.UploadPath = appSettings.Value.UploadPath;    
            ViewBag.AssetsUrl = this.AssetsUrl;
            ViewBag.UploadPath = this.UploadPath;
            base.OnActionExecuting(filterContext);
        }

        
    }
}
