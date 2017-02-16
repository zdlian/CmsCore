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
    public class PageController : BaseController
    {
        private readonly IPageService pageService;
        private readonly ITemplateService templateService;
        public PageController(IPageService pageService, ITemplateService templateService)
        {
            this.pageService = pageService;
            this.templateService = templateService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var pages = pageService.GetPages();
            return View(pages);
        }

        public IActionResult Create()
        {
            ViewBag.ParentPages = new SelectList(pageService.GetPages(), "Id", "Title");
            ViewBag.Templates = new SelectList(templateService.GetTemplates(), "Id", "Name");
            var pageVM = new PageViewModel();
            return View(pageVM);
        }
        [HttpPost]
        public IActionResult Create(PageViewModel pageVM)
        {
            
            if (ModelState.IsValid)
            {
                Page page = new Page();
                page.Title = pageVM.Title;
                page.Slug = pageVM.Slug;
                page.Body = pageVM.Body;
                page.IsPublished = pageVM.IsPublished;
                page.ParentPageId = pageVM.ParentPageId;
                page.TemplateId = pageVM.TemplateId;
                page.SeoTitle = pageVM.SeoTitle;
                page.SeoKeywords = pageVM.SeoKeywords;
                page.SeoDescription = pageVM.SeoDescription;
                page.AddedBy = "Nex";
                page.AddedDate = DateTime.Now;
                page.ModifiedBy = "Nex";
                page.ModifiedDate = DateTime.Now;
                pageService.CreatePage(page);
                pageService.SavePage();
                return RedirectToAction("Index", "Page");
            }
            ViewBag.ParentPages = new SelectList(pageService.GetPages(), "Id", "Title", pageVM.ParentPageId);
            ViewBag.Templates = new SelectList(templateService.GetTemplates(), "Id", "Name", pageVM.TemplateId);
            return View(pageVM);
        }

        public IActionResult Edit(long id)
        {
            var page = pageService.GetPage(id);
            ViewBag.ParentPages = new SelectList(pageService.GetPages(), "Id", "Title", page.ParentPageId);
            ViewBag.Templates = new SelectList(templateService.GetTemplates(), "Id", "Name", page.TemplateId);
            PageViewModel pageVM = new PageViewModel();
            pageVM.Id = page.Id;
            pageVM.Title = page.Title;
            pageVM.Slug = page.Slug;
            pageVM.Body = page.Body;
            pageVM.IsPublished = page.IsPublished;
            pageVM.ParentPageId = page.ParentPageId;
            pageVM.TemplateId = page.TemplateId;
            pageVM.ModifiedDate = page.ModifiedDate;
            pageVM.ModifiedBy = page.ModifiedBy;
            pageVM.AddedBy = page.AddedBy;
            pageVM.AddedDate = page.AddedDate;
            pageVM.SeoTitle = page.SeoTitle;
            pageVM.SeoDescription = page.SeoDescription;
            pageVM.SeoKeywords = page.SeoKeywords;
            return View(pageVM);
        }

        [HttpPost]
        public IActionResult Edit(PageViewModel pageVM)
        {
            if (ModelState.IsValid)
            {
                Page page = pageService.GetPage(pageVM.Id);
                page.Id = pageVM.Id;
                page.Title = pageVM.Title;
                page.Slug = pageVM.Slug;
                page.Body = pageVM.Body;
                page.IsPublished = pageVM.IsPublished;
                page.ParentPageId = pageVM.ParentPageId;
                page.TemplateId = pageVM.TemplateId;
                page.ModifiedDate = DateTime.Now;
                page.ModifiedBy = User.Identity.Name??"Anonim";
                page.SeoTitle = pageVM.SeoTitle;
                page.SeoDescription = pageVM.SeoDescription;
                page.SeoKeywords = pageVM.SeoKeywords;
                pageService.UpdatePage(page);
                pageService.SavePage();
                return RedirectToAction("Index", "Page");
            }
            ViewBag.ParentPages = new SelectList(pageService.GetPages(), "Id", "Title", pageVM.ParentPageId);
            ViewBag.Templates = new SelectList(templateService.GetTemplates(), "Id", "Name", pageVM.TemplateId);
            return View(pageVM);
        }

        public IActionResult Delete(long id)
        {
            pageService.DeletePage(id);
            pageService.SavePage();
            return RedirectToAction("Index", "Page");
        }

        public ActionResult Details(int id)
        {
            var page = pageService.GetPage(id);
            return View(page);
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
