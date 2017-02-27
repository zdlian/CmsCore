using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CmsCore.Service;
using CmsCore.Model.Entities;
using CmsCore.Admin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CmsCore.Admin.Controllers
{
    public class LinkController : BaseController
    {
        private readonly ILinkService linkService;
        private readonly ISectionService sectionService;

        public LinkController(ILinkService linkService, ISectionService sectionService)
        {
            this.linkService = linkService;
            this.sectionService = sectionService;

        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            LinkViewModel linkVM = new LinkViewModel();
            return View();

        }
        [HttpPost]
        public IActionResult Create(LinkViewModel linkVM)
        {
            if (ModelState.IsValid)
            {
                Link link = new Link();
                link.Name = linkVM.Name;
                link.Url = linkVM.Url;
                link.IsVisible = linkVM.IsVisible;
                link.Description = linkVM.Description;
                link.Target = linkVM.Target;
                link.AddedBy = "CEVDET";
                link.AddedDate = DateTime.Now;
                link.ModifiedBy = "CEVDET";
                link.ModifiedDate = DateTime.Now;
                linkService.CreateLink(link);
                linkService.SaveLink();
                return RedirectToAction("Index", "Link");
            }
         
            return View(linkVM);
        }
        public IActionResult Edit(long id)
        {

            var link = linkService.GetLink(id);
            LinkViewModel linkVM = new LinkViewModel();
            linkVM.Name = link.Name;
            linkVM.Url = link.Url;
            linkVM.IsVisible = link.IsVisible;
            linkVM.Description = link.Description;
            linkVM.Target = link.Target;
           
            
            return View(linkVM);
        }
        [HttpPost]
        public IActionResult Edit(LinkViewModel linkVM)
        {
            if (ModelState.IsValid)
            {
                Link link = linkService.GetLink(linkVM.Id);
                link.Name = linkVM.Name;
                link.Url = linkVM.Url;
                link.IsVisible = linkVM.IsVisible;
                link.Description = linkVM.Description;
                link.Target  = linkVM.Target;
              
                linkService.UpdateLink(link);
                linkService.SaveLink();
                return RedirectToAction("Index", "Link");
            }
          
            return View(linkVM);
        }
        public IActionResult Delete(long id)
        {
            linkService.DeleteLink(id);
            linkService.SaveLink();
            return RedirectToAction("Index", "Link");
        }
        public IActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var sortColumnIndex = Convert.ToInt32(Request.Query["iSortCol_0"]);
            var sortDirection = Request.Query["sSortDir_0"]; // asc or desc
            int iTotalRecords;
            int iTotalDisplayRecords;
            var displayedPages = linkService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);

            var result = from p in displayedPages
                         select new[]{
                             p.Id.ToString(),
                             p.Id.ToString(),
                             p.Name.ToString(),
                             p.Url.ToString(),
                             (p.Description != null?p.Description.ToString():string.Empty),
                             (p.Target != null?p.Target.ToString():string.Empty),
                             p.IsVisible.ToString(),

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
