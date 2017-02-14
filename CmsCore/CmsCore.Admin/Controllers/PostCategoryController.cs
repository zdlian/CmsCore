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
            ViewBag.Category = new SelectList(postCategoryService.GetPostCategories(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(PostCategoryViewModel postCategoryVM)
        {
            ViewBag.Category = new SelectList(postCategoryService.GetPostCategories(), "Id", "Name");
            if (ModelState.IsValid)
            {
                var postCategory = new PostCategory();
                postCategoryService.CreatePostCategory(postCategory);
                postCategoryService.SavePostCategory();
                return RedirectToAction("Index");
            }
            return View(postCategoryVM);
        }
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var postCategory = postCategoryService.GetPostCategory(id.Value);
                if (postCategory != null)
                {
                    //var categoryViewModel = Mapper.Map<Category, CategoryViewModel>(category);

                    PostCategoryViewModel pvm = new PostCategoryViewModel();
                    pvm.Id = postCategory.Id;
                    pvm.Name = postCategory.Name;
                    pvm.Slug = postCategory.Slug;
                    pvm.Description = postCategory.Description;
                    pvm.ParentCategoryId = postCategory.ParentCategoryId;
                    pvm.AddedBy = postCategory.AddedBy;
                    pvm.AddedDate = postCategory.AddedDate;
                    pvm.ModifiedBy = postCategory.ModifiedBy;
                    pvm.ModifiedDate = postCategory.ModifiedDate;
                    return View(pvm);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        
        public ActionResult Edit(PostCategoryViewModel pvm)
        {
            if (ModelState.IsValid)
            {
                PostCategory pc = new PostCategory();
                pc.Id = pvm.Id;
                pc.Name = pvm.Name;
                pc.Slug = pvm.Slug;
                pc.Description = pvm.Description;
                pc.ParentCategoryId = pvm.ParentCategoryId;
                pc.AddedBy = pvm.AddedBy;
                pc.AddedDate = pvm.AddedDate;
                pc.ModifiedBy = pvm.ModifiedBy;
                pc.ModifiedDate = pvm.ModifiedDate;
                postCategoryService.UpdatePostCategory(pc);
                postCategoryService.SavePostCategory();
                return RedirectToAction("Index");
            }
            //ViewBag.ParentCategories = new SelectList(postCategoryService.GetCategories(), "CategoryId", "CategoryName", categoryForm.ParentCategoryId);
            return View(pvm);
        }
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var category = postCategoryService.GetPostCategory(id.Value);
                if (category != null)
                {
                    postCategoryService.DeletePostCategory(category);
                    postCategoryService.SavePostCategory();
                    return RedirectToAction("Index");
                }
            }
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
            var result = from c in displayedCategories select new[] { c.Id.ToString(), c.Id.ToString(), c.Name, c.Slug, c.Description.ToString(), string.Empty }; // Post Count alanı vardı Description'a çevirdim
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

