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
    public class LanguageController : BaseController
    {
        private readonly ILanguageService languageService;
        private readonly ISectionService sectionService;

        public LanguageController(ILanguageService languageService, ISectionService sectionService)
        {
            this.languageService = languageService;
            this.sectionService = sectionService;

        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(LanguageViewModel languageVM)
        {
            if (ModelState.IsValid)
            {
                Language language = new Language();
                language.Name = languageVM.Name;
                language.NativeName = languageVM.NativeName;
                language.Culture = languageVM.Culture;

                languageService.CreateLanguage(language);
                languageService.SaveLanguage();
                return RedirectToAction("Index", "Language");
            }
          
            return View(languageVM);
        }
        public IActionResult Edit(long id)
        {

            var language = languageService.GetLanguage(id);
            LanguageViewModel languageVM = new LanguageViewModel();
            
            languageVM.Name = language.Name;
            languageVM.NativeName = language.NativeName;
            languageVM.Culture = language.Culture;
            return View(languageVM);
        }
        [HttpPost]
        public IActionResult Edit(LanguageViewModel languageVM)
        {
            if (ModelState.IsValid)
            {
                Language language = languageService.GetLanguage(languageVM.Id);
                language.Name = languageVM.Name;
                language.NativeName = languageVM.NativeName;
                language.Culture = languageVM.Culture;

                languageService.UpdateLanguage(language);
                languageService.SaveLanguage();
                return RedirectToAction("Index", "Language");
            }
           
            return View(languageVM);
        }
        public IActionResult Delete(long id)
        {
            languageService.DeleteLanguage(id);
            languageService.SaveLanguage();
            return RedirectToAction("Index", "Language");
        }
        public IActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var sortColumnIndex = Convert.ToInt32(Request.Query["iSortCol_0"]);
            var sortDirection = Request.Query["sSortDir_0"]; // asc or desc
            int iTotalRecords;
            int iTotalDisplayRecords;
            var displayedPages = languageService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);

            var result = from p in displayedPages
                         select new[]{
                             p.Id.ToString(),
                             
                             p.Name.ToString(),
                             p.NativeName.ToString(),
                             p.Culture.ToString(),
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
