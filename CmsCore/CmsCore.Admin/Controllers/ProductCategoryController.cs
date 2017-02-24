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
    public class ProductCategoryController : BaseController
    {
        private readonly IProductCategoryService productCategoryService;
        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            this.productCategoryService = productCategoryService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var productCVM = new ProductCategoryViewModel();
            ViewBag.ProductCategories = new SelectList(productCategoryService.GetProductCategories(), "Id", "Name");
            return View(productCVM);
        }
        [HttpPost]
        public ActionResult Create(ProductCategoryViewModel productCVM)
        {

            if (ModelState.IsValid)
            {
                var productCategory = new ProductCategory();
                productCategory.Name = productCVM.Name;
                productCategory.Slug = productCVM.Slug;
                productCategory.Description = productCVM.Description;
                productCategory.ParentCategoryId = productCVM.ParentCategoryId;
                productCategoryService.CreateProductCategory(productCategory);
                productCategoryService.SaveProductCategory();
                return RedirectToAction("Index");
            }
            ViewBag.ProductCategories = new SelectList(productCategoryService.GetProductCategories(), "Id", "Name", productCVM.ParentCategoryId);
            return View(productCVM);
        }
        public ActionResult Edit(long id)
        {
            var productCategory = productCategoryService.GetProductCategory(id);
            if (productCategory != null)
            {

                ProductCategoryViewModel productCVM = new ProductCategoryViewModel();
                productCVM.Id = productCategory.Id;
                productCVM.Name = productCategory.Name;
                productCVM.Slug = productCategory.Slug;
                productCVM.Description = productCategory.Description;
                productCVM.ParentCategoryId = productCategory.ParentCategoryId;
                ViewBag.ProductCategories = new SelectList(productCategoryService.GetProductCategories(), "Id", "Name", productCategory.ParentCategoryId);
                return View(productCVM);
            }

            return RedirectToAction("Index");
        }
        [HttpPost]

        public ActionResult Edit(ProductCategoryViewModel productCVM)
        {
            if (ModelState.IsValid)
            {
                ProductCategory pc = productCategoryService.GetProductCategory(productCVM.Id);
                pc.Name = productCVM.Name;
                pc.Slug = productCVM.Slug;
                pc.Description = productCVM.Description;
                pc.ParentCategoryId = productCVM.ParentCategoryId;
                productCategoryService.UpdateProductCategory(pc);
                productCategoryService.SaveProductCategory();
                return RedirectToAction("Index");
            }
            ViewBag.ProductCategories = new SelectList(productCategoryService.GetProductCategories(), "Id", "Name", productCVM.ParentCategoryId);
            return View(productCVM);
        }
        public ActionResult Delete(long id)
        {
            productCategoryService.DeleteProductCategory(id);
            productCategoryService.SaveProductCategory();
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
            var displayedCategories = productCategoryService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);
            var result = from c in displayedCategories
                         select new[] {
                             c.Id.ToString(),
                             c.Id.ToString(),
                             c.Name,
                             c.Slug,
                             c.ProductProductCategories.Count().ToString(),
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

