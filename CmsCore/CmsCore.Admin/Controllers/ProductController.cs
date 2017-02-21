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
    public class ProductController : BaseController
    {
        private readonly IProductService productService;
        private readonly ITemplateService templateService;
        public ProductController(IProductService productService, ITemplateService templateService)
        {
            this.productService = productService;
            this.templateService = templateService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var products = productService.GetProducts();
            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.ParentProducts = new SelectList(productService.GetProducts(), "Id", "Title");
            var productVM = new ProductViewModel();
            return View(productVM);
        }
        [HttpPost]
        public IActionResult Create(ProductViewModel productVM)
        {

            if (ModelState.IsValid)
            {
                Product product = new Product();
                product.Title = productVM.Title;
                product.Slug = productVM.Slug;
                product.Body = productVM.Body;
                product.Code = productVM.Code;
                product.Photo = productVM.Photo;
                product.Price = productVM.Price;
                product.OldPrice = productVM.OldPrice;
                product.IsNew = productVM.IsNew;
                product.IsAvailable = productVM.IsAvailable;
                product.IsPublished = productVM.IsPublished;
                product.ParentProductId = productVM.ParentProductId;
                product.SeoTitle = productVM.SeoTitle;
                product.SeoKeywords = productVM.SeoKeywords;
                product.SeoDescription = productVM.SeoDescription;
                product.AddedBy = "CEVDET";
                product.AddedDate = DateTime.Now;
                product.ModifiedBy = "CEVDET";
                product.ModifiedDate = DateTime.Now;
                productService.CreateProduct(product);
                productService.SaveProduct();
                return RedirectToAction("Index", "Product");
            }
            ViewBag.ParentProducts = new SelectList(productService.GetProducts(), "Id", "Title", productVM.ParentProductId);
            return View(productVM);
        }

        public IActionResult Edit(long id)
        {
            var product = productService.GetProduct(id);
            ViewBag.ParentProducts = new SelectList(productService.GetProducts(), "Id", "Title", product.ParentProductId);
            ProductViewModel productVM = new ProductViewModel();
            productVM.Id = product.Id;
            productVM.Title = product.Title;
            productVM.Slug = product.Slug;
            productVM.Body = product.Body;
            productVM.Code = product.Code;
            productVM.Photo = product.Photo;
            productVM.Price = product.Price;
            productVM.OldPrice = product.OldPrice;
            productVM.IsNew = product.IsNew;
            productVM.IsAvailable = product.IsAvailable;
            productVM.IsPublished = product.IsPublished;
            productVM.ParentProductId = product.ParentProductId;
            productVM.ModifiedDate = product.ModifiedDate;
            productVM.ModifiedBy = product.ModifiedBy;
            productVM.AddedBy = product.AddedBy;
            productVM.AddedDate = product.AddedDate;
            productVM.SeoTitle = product.SeoTitle;
            productVM.SeoDescription = product.SeoDescription;
            productVM.SeoKeywords = product.SeoKeywords;
            return View(productVM);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel productVM)
        {
            if (ModelState.IsValid)
            {
                Product product = productService.GetProduct(productVM.Id);
                product.Id = productVM.Id;
                product.Title = productVM.Title;
                product.Slug = productVM.Slug;
                product.Code = productVM.Code;
                product.Photo = productVM.Photo;
                product.Price = productVM.Price;
                product.OldPrice = productVM.OldPrice;
                product.IsNew = productVM.IsNew;
                product.IsAvailable = productVM.IsAvailable;
                product.Body = productVM.Body;
                product.IsPublished = productVM.IsPublished;
                product.ParentProductId = productVM.ParentProductId;
                product.ModifiedDate = DateTime.Now;
                product.ModifiedBy = User.Identity.Name ?? "Anonim";
                product.SeoTitle = productVM.SeoTitle;
                product.SeoDescription = productVM.SeoDescription;
                product.SeoKeywords = productVM.SeoKeywords;
                productService.UpdateProduct(product);
                productService.SaveProduct();
                return RedirectToAction("Index", "Product");
            }
            ViewBag.ParentProducts = new SelectList(productService.GetProducts(), "Id", "Title", productVM.ParentProductId);
            return View(productVM);
        }

        public IActionResult Delete(long id)
        {
            productService.DeleteProduct(id);
            productService.SaveProduct();
            return RedirectToAction("Index", "Product");
        }

        public IActionResult Details(long id)
        {
            var product = productService.GetProduct(id);
            return View(product);
        }

        public IActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var sortColumnIndex = Convert.ToInt32(Request.Query["iSortCol_0"]);
            var sortDirection = Request.Query["sSortDir_0"]; // asc or desc
            int iTotalRecords;
            int iTotalDisplayRecords;
            var displayedProducts = productService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);

            var result = from p in displayedProducts
                         select new[] {
                             p.Id.ToString(),
                             p.Title.ToString(),
                             p.AddedBy.ToString(),
                             p.ViewCount.ToString(),
                             p.ModifiedDate.ToString(),
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
