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
    public class SectionController : BaseController
    {
        private readonly ISectionService sectionService;

        public SectionController(ISectionService sectionService)
        {
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
        public IActionResult Create(SectionViewModel sectionVM)
        {
            if (ModelState.IsValid)
            {
                Section section = new Section();
                section.Name = sectionVM.Name;
                section.AddedBy = "CEVDET";
                section.AddedDate = DateTime.Now;
                section.ModifiedBy = "CEVDET";
                section.ModifiedDate = DateTime.Now;
                sectionService.CreateSection(section);
                sectionService.SaveSection();
                return RedirectToAction("Index", "Section");
            }
            
            return View(sectionVM);
        }
        public IActionResult Edit(long id)
        {
            var section = sectionService.GetSection(id);
            SectionViewModel sectionVM = new SectionViewModel();
            sectionVM.Id = section.Id;
            sectionVM.Name = section.Name;
            return View(sectionVM);
        }
        [HttpPost]
        public IActionResult Edit(SectionViewModel sectionVM)
        {
            if (ModelState.IsValid)
            {
                Section sec = sectionService.GetSection(sectionVM.Id);
                sectionService.UpdateSection(sec);
                sec.Name = sectionVM.Name;
                sectionService.SaveSection();
                return RedirectToAction("Index", "Section");
            }
            
            return View(sectionVM);
        }
        public IActionResult Delete(long id)
        {
            sectionService.DeleteSection(id);
            sectionService.SaveSection();
            return RedirectToAction("Index", "Section");
        }
        public IActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var sortColumnIndex = Convert.ToInt32(Request.Query["iSortCol_0"]);
            var sortDirection = Request.Query["sSortDir_0"]; // asc or desc
            int iTotalRecords;
            int iTotalDisplayRecords;
            var displayedPages = sectionService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);

            var result = from p in displayedPages
                         select new[]{
                             p.Id.ToString(),
                             p.Id.ToString(),
                             p.Name.ToString(),
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
