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
    public class PostCategoryController : BaseController
    {
        private readonly IPostCategoryService postCategoryService;
        public PostCategoryController(IPostCategoryService postCategoryService)
        {
            this.postCategoryService = postCategoryService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var postCategoryVM = new PostCategoryViewModel();
            ViewBag.PostCategories = new SelectList(postCategoryService.GetPostCategories(), "Id", "Name");
            return View(postCategoryVM);
        }
        [HttpPost]
        public ActionResult Create(PostCategoryViewModel postCategoryVM){
            
            if (ModelState.IsValid){
                var postCategory = new PostCategory();
                postCategory.Name = postCategoryVM.Name;
                postCategory.Slug = postCategoryVM.Slug;
                postCategory.Description = postCategoryVM.Description;
                postCategory.ParentCategoryId = postCategoryVM.ParentCategoryId;
                postCategoryService.CreatePostCategory(postCategory);
                postCategoryService.SavePostCategory();
                return RedirectToAction("Index");
            }
            ViewBag.PostCategories = new SelectList(postCategoryService.GetPostCategories(), "Id", "Name", postCategoryVM.ParentCategoryId);
            return View(postCategoryVM);
        }
        public ActionResult Edit(long id)
        {
            var postCategory = postCategoryService.GetPostCategory(id);
            if (postCategory != null)
            {
                    
                PostCategoryViewModel pvm = new PostCategoryViewModel();
                pvm.Id = postCategory.Id;
                pvm.Name = postCategory.Name;
                pvm.Slug = postCategory.Slug;
                pvm.Description = postCategory.Description;
                pvm.ParentCategoryId = postCategory.ParentCategoryId;
                ViewBag.PostCategories = new SelectList(postCategoryService.GetPostCategories(), "Id", "Name", postCategory.ParentCategoryId);
                return View(pvm);
            }
         
            return RedirectToAction("Index");
        }
        [HttpPost]
        
        public ActionResult Edit(PostCategoryViewModel pvm)
        {
            if (ModelState.IsValid)
            {
                PostCategory pc = postCategoryService.GetPostCategory(pvm.Id);
                pc.Name = pvm.Name;
                pc.Slug = pvm.Slug;
                pc.Description = pvm.Description;
                pc.ParentCategoryId = pvm.ParentCategoryId;
                postCategoryService.UpdatePostCategory(pc);
                postCategoryService.SavePostCategory();
                return RedirectToAction("Index");
            }
            ViewBag.PostCategories = new SelectList(postCategoryService.GetPostCategories(), "Id", "Name", pvm.ParentCategoryId);
            return View(pvm);
        }
        public ActionResult Delete(long id)
        {
            postCategoryService.DeletePostCategory(id);
            postCategoryService.SavePostCategory();
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
            var displayedCategories = postCategoryService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);
            var result = from c in displayedCategories select new[] { c.Id.ToString(), c.Id.ToString(), c.Name, c.Slug, c.PostPostCategories.Count().ToString(), string.Empty }; // Post Count alanı vardı Description'a çevirdim
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

