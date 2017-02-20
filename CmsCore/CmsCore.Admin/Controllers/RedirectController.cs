using CmsCore.Admin.Models;
using CmsCore.Model.Entities;
using CmsCore.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Admin.Controllers
{
    public class RedirectController:BaseController
    {
        private readonly IRedirectService redirectService;
        public RedirectController(IRedirectService redirectService) {
            this.redirectService = redirectService;
        }
        public IActionResult Index() {
            return View();
        }
        public IActionResult Create() {
            var redirectVM = new RedirectViewModel();
            return View(redirectVM);
            
        }
        [HttpPost]
        public IActionResult Create(RedirectViewModel redirectVM) {
            if (ModelState.IsValid) {
                Redirect redirect = new Redirect();
                redirect.Name = redirectVM.Name;
                redirect.OldUrl = redirectVM.OldUrl;
                redirect.NewUrl = redirectVM.NewUrl;
                redirect.IsActive = redirectVM.IsActive;
                redirect.AddedBy = "Nex";
                redirect.AddedDate = DateTime.Now;
                redirect.ModifiedBy = "Nex";
                redirect.ModifiedDate = DateTime.Now;
                redirectService.CreateRedirect(redirect);
                redirectService.SaveRedirect();
                return RedirectToAction("Index", "Redirect");
            }
            return View(redirectVM);
        }
        public IActionResult Edit(long id) {
            var redirect = redirectService.GetRedirect(id);
            RedirectViewModel redirectVM = new RedirectViewModel();
            redirectVM.Id = redirect.Id;
            redirectVM.Name = redirect.Name;
            redirectVM.OldUrl = redirect.OldUrl;
            redirectVM.NewUrl = redirect.NewUrl;
            redirectVM.IsActive = redirect.IsActive;
            redirectVM.ModifiedDate = redirect.ModifiedDate;
            redirectVM.ModifiedBy = redirect.ModifiedBy;
            redirectVM.AddedBy = redirect.AddedBy;
            return View(redirectVM);
        }
        [HttpPost]
        public IActionResult Edit(RedirectViewModel redirectVM) {
            if (ModelState.IsValid){
                Redirect redirect = redirectService.GetRedirect(redirectVM.Id);
                redirect.Id = redirectVM.Id;
                redirect.Name = redirectVM.Name;
                redirect.OldUrl= redirectVM.OldUrl;
                redirect.NewUrl= redirectVM.NewUrl;
                redirect.IsActive = redirectVM.IsActive;
                redirect.ModifiedDate = DateTime.Now;
                redirect.ModifiedBy = User.Identity.Name ?? "Anonim";
                redirectService.UpdateRedirect(redirect);
                redirectService.SaveRedirect();
                return RedirectToAction("Index", "Redirect");
            }
            return View(redirectVM);
        }
        public IActionResult Delete(long id) {
            redirectService.DeleteRedirect(id);
            redirectService.SaveRedirect();
            return RedirectToAction("Index", "Redirect");
        }
        public IActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var sortColumnIndex = Convert.ToInt32(Request.Query["iSortCol_0"]);
            var sortDirection = Request.Query["sSortDir_0"]; // asc or desc
            int iTotalRecords;
            int iTotalDisplayRecords;
            var displayedRedirects = redirectService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);

            var result = from p in displayedRedirects
                         select new[]{
                          
                             p.Id.ToString(),
                             p.Name.ToString(),
                          p.OldUrl,
                          p.NewUrl,
                          p.IsActive.ToString(),
                             string.Empty
                         };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = iTotalRecords,
                iTotalDisplayRecords = iTotalDisplayRecords,
                aaData = result.ToList()
            });
        }
    }
}
