using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CmsCore.Service;
using CmsCore.Model.Entities;
using CmsCore.Admin.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CmsCore.Admin.Controllers
{
    public class PageController : BaseController
    {
        private readonly IPageService pageService;
        public PageController(IPageService pageService)
        {
            this.pageService = pageService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var pages = pageService.GetPages();
            return View(pages);
        }

        public IActionResult Create()
        {
            var page = new Page();
            return View(page);
        }
        [HttpPost]
        public IActionResult Create(Page page)
        {
            if (ModelState.IsValid)
            {
                pageService.CreatePage(page);
                pageService.SavePage();
                return RedirectToAction("Index", "Pages");
            }
            return View(page);
        }

        public IActionResult Edit(long id)
        {
            var page = pageService.GetPage(id);
            return View(page);
        }

        [HttpPost]
        public IActionResult Edit(Page page)
        {
            if (ModelState.IsValid)
            {
                pageService.UpdatePage(page);
                pageService.SavePage();
                return RedirectToAction("Index", "Pages");
            }
            return View(page);
        }

        public IActionResult Delete(long id)
        {
            pageService.DeletePage(id);
            pageService.SavePage();
            return RedirectToAction("Index", "Pages");
        }

        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var sortColumnIndex = Convert.ToInt32(Request.Query["iSortCol_0"]);
            var sortDirection = Request.Query["sSortDir_0"]; // asc or desc
            int iTotalRecords;
            int iTotalDisplayRecords;
            var displayedPages = pageService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);

            var result = from p in displayedPages
                         select new[] { p.Id.ToString(), p.Title.ToString(), p.AddedBy.ToString(), p.ViewCount.ToString(), p.ModifiedDate.ToString(), string.Empty };
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
