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
    public class LinkCategoryController : BaseController
    {
        private readonly ILinkCategoryService linkCategoryService;
        public LinkCategoryController(ILinkCategoryService linkCategoryService)
        {
            this.linkCategoryService = linkCategoryService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var linkCVM = new LinkCategoryViewModel();
            ViewBag.LinkCategories = new SelectList(linkCategoryService.GetLinkCategories(), "Id", "Name");
            return View(linkCVM);
        }
        [HttpPost]
        public ActionResult Create(LinkCategoryViewModel linkCVM)
        {

            if (ModelState.IsValid)
            {
                var linkCategory = new LinkCategory();
                linkCategory.Name = linkCVM.Name;
                linkCategory.Slug = linkCVM.Slug;
                linkCategory.Description = linkCVM.Description;
                linkCategory.ParentCategoryId = linkCVM.ParentCategoryId;
                linkCategoryService.CreateLinkCategory(linkCategory);
                linkCategoryService.SaveLinkCategory();
                return RedirectToAction("Index");
            }
            ViewBag.LinkCategories = new SelectList(linkCategoryService.GetLinkCategories(), "Id", "Name", linkCVM.ParentCategoryId);
            return View(linkCVM);
        }
        public ActionResult Edit(long id)
        {
            var linkCategory = linkCategoryService.GetLinkCategory(id);
            if (linkCategory != null)
            {

                LinkCategoryViewModel linkCVM = new LinkCategoryViewModel();
                linkCVM.Id = linkCategory.Id;
                linkCVM.Name = linkCategory.Name;
                linkCVM.Slug = linkCategory.Slug;
                linkCVM.Description = linkCategory.Description;
                linkCVM.ParentCategoryId = linkCategory.ParentCategoryId;
                ViewBag.LinkCategories = new SelectList(linkCategoryService.GetLinkCategories(), "Id", "Name", linkCategory.ParentCategoryId);
                return View(linkCVM);
            }

            return RedirectToAction("Index");
        }
        [HttpPost]

        public ActionResult Edit(LinkCategoryViewModel linkCVM)
        {
            if (ModelState.IsValid)
            {
                LinkCategory pc = linkCategoryService.GetLinkCategory(linkCVM.Id);
                pc.Name = linkCVM.Name;
                pc.Slug = linkCVM.Slug;
                pc.Description = linkCVM.Description;
                pc.ParentCategoryId = linkCVM.ParentCategoryId;
                linkCategoryService.UpdateLinkCategory(pc);
                linkCategoryService.SaveLinkCategory();
                return RedirectToAction("Index");
            }
            ViewBag.LinkCategories = new SelectList(linkCategoryService.GetLinkCategories(), "Id", "Name", linkCVM.ParentCategoryId);
            return View(linkCVM);
        }
        public ActionResult Delete(long id)
        {
            linkCategoryService.DeleteLinkCategory(id);
            linkCategoryService.SaveLinkCategory();
            return RedirectToAction("Index");
        }

        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var sortColumnIndex = Convert.ToInt32(Request.Query["iSortCol_0"]);
            var sortDirection = Request.Query["sSortDir_0"];
            int iTotalRecords;
            int iTotalDisplayRecords;
            var displayedCategories = linkCategoryService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);
            var result = from c in displayedCategories
                         select new[] {
                             c.Id.ToString(),
                             c.Id.ToString(),
                             c.Name,
                             c.Slug,
                             c.LinkLinkCategories.Count().ToString(),
                             string.Empty };
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

