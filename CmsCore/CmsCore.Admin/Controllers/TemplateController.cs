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
    public class TemplateController : BaseController
    {
        private readonly ITemplateService templateService;
        public TemplateController(ITemplateService templateService)
        {
            this.templateService = templateService;
            
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var templates = templateService.GetTemplates();
            return View(templates);
        }

        public IActionResult Create()
        {
          
            var templateVM = new TemplateViewModel();
            return View(templateVM);
        }
        [HttpPost]
        public IActionResult Create(TemplateViewModel templateVM)
        {
            
            if (ModelState.IsValid)
            {
                Template template = new Template();
                template.Name = templateVM.Name;
                template.ViewName = templateVM.ViewName;
                template.AddedBy = "Nex";
                template.AddedDate = DateTime.Now;
                template.ModifiedBy = "Nex";
                template.ModifiedDate = DateTime.Now;
                templateService.CreateTemplate(template);
                templateService.SaveTemplate();
                return RedirectToAction("Index", "Template");
            }
            
            return View(templateVM);
        }

        public IActionResult Edit(long id)
        {
            var template = templateService.GetTemplate(id);
          
            TemplateViewModel templateVM = new TemplateViewModel();
            templateVM.Id = template.Id;
            templateVM.Name = template.Name;
            templateVM.ViewName = template.ViewName;
            templateVM.ModifiedDate = template.ModifiedDate;
            templateVM.ModifiedBy = template.ModifiedBy;
            templateVM.AddedBy = template.AddedBy;
            templateVM.AddedDate = template.AddedDate;
          
            return View(templateVM);
        }

        [HttpPost]
        public IActionResult Edit(TemplateViewModel templateVM)
        {
            if (ModelState.IsValid)
            {
                Template template = templateService.GetTemplate(templateVM.Id);
                template.Id = templateVM.Id;
                template.Name = templateVM.Name;
                template.ViewName = templateVM.ViewName;
                
                template.ModifiedDate = DateTime.Now;
                template.ModifiedBy = User.Identity.Name??"Anonim";
               
                templateService.UpdateTemplate(template);
                templateService.SaveTemplate();
                return RedirectToAction("Index", "template");
            }
            
            return View(templateVM);
        }

        public IActionResult Delete(long id)
        {
            templateService.DeleteTemplate(id);
            templateService.SaveTemplate();
            return RedirectToAction("Index", "template");
        }

        public ActionResult Details(int id)
        {
            var template = templateService.GetTemplate(id);
            return View(template);
        }

        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var sortColumnIndex = Convert.ToInt32(Request.Query["iSortCol_0"]);
            var sortDirection = Request.Query["sSortDir_0"]; // asc or desc
            int iTotalRecords;
            int iTotalDisplayRecords;
            var displayedtemplates = templateService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);

            var result = from p in displayedtemplates
                         select new[] { p.Id.ToString(), p.Name.ToString(), p.ViewName.ToString(), p.AddedBy.ToString(), p.ModifiedDate.ToString(), string.Empty };
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
