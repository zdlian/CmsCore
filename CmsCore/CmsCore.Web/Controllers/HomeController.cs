using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CmsCore.Service;
using CmsCore.Web.Models;

namespace CmsCore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPageService pageService;
        public HomeController (IPageService pageService)
        {
            this.pageService = pageService;
        }
        public IActionResult Index(string slug = "")
        {
            if (slug != "") {
                // Do redirect operations

                // get page by slug

                // if page is null get post by slug

                // if post is null get product by slug

                // if product is null display 404 not found page

                
            }
            // get home page
            var homePage = pageService.GetPageBySlug("anasayfa");
            PageViewModel pageVM = new PageViewModel();
            pageVM.Id = homePage.Id;
            pageVM.Title = homePage.Title;
            pageVM.Slug = homePage.Slug;
            pageVM.Body = homePage.Body;
            pageVM.Template = homePage.Template;
            pageVM.SeoTitle = homePage.SeoTitle;
            pageVM.SeoKeywords = homePage.SeoKeywords;
            pageVM.SeoDescription = homePage.SeoDescription;
            if (homePage.Template != null)
            {
                return View(homePage.Template.ViewName, pageVM);
            }
            return View(pageVM);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
