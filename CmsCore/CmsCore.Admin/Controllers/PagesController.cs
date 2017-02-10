using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CmsCore.Service;
using CmsCore.Model.Entities;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CmsCore.Admin.Controllers
{
    public class PagesController : Controller
    {
        private readonly IPageService pageService;
        public PagesController(IPageService pageService)
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
    }
}
