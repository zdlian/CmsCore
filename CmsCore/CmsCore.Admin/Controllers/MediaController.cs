using CmsCore.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Admin.Controllers
{
    public class MediaController:BaseController
    {
        public IActionResult Index() {
            return View();
        }
        public IActionResult Create() {
            return View();
        }
        //public IActionResult Create(MediaViewModel fileVM, HttpPostedFileBase upload) {
        //    return View();
        //}
    }
}
