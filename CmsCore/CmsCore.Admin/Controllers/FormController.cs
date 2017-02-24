using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CmsCore.Service;
using CmsCore.Admin.Models;
using CmsCore.Model.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CmsCore.Admin.Controllers
{
    public class FormController : BaseController
    {
        private readonly IFormService formService;
        private readonly IFormFieldService formFieldService;
        public FormController(IFormService formService, IFormFieldService formFieldService)
        {
            this.formService = formService;
            this.formFieldService = formFieldService;
        }
        // GET: Form
        public ActionResult Create()
        {
            var form = new FormViewModel();
            return View(form);
        }

        [HttpPost]
        public ActionResult Create(FormViewModel form)
        {
            if (ModelState.IsValid)
            {
                var frm = new Form();
                frm.Id = form.Id;
                frm.FormName = form.FormName;
                frm.Description = form.Description;
                frm.ClosingDescription = form.ClosingDescription;
                frm.EmailTo = form.EmailTo;
                frm.EmailCc = form.EmailCc;
                frm.EmailBcc = form.EmailBcc;  
                frm.GoogleAnalyticsCode = form.GoogleAnalyticsCode;
                frm.IsPublished = form.IsPublished;
                formService.CreateForm(frm);
                formService.SaveForm();
                return RedirectToAction("Index");

            }
            return View(form);

        }
        public ActionResult Details(long id)
        {
            var frm = formService.GetForm(id);
            if (frm != null)
            {
                ViewBag.FormFields = new List<FormField>(formService.GetFormFieldsByFormId(id));
                var formViewModel = new FormViewModel();
                formViewModel.Id = frm.Id;
                formViewModel.FormName = frm.FormName;
                formViewModel.Description = frm.Description;
                formViewModel.ClosingDescription = frm.ClosingDescription;
                formViewModel.EmailTo = frm.EmailTo;
                formViewModel.EmailCc = frm.EmailCc;
                formViewModel.EmailBcc = frm.EmailBcc;
                formViewModel.FormFields = frm.FormFields;
                formViewModel.GoogleAnalyticsCode = frm.GoogleAnalyticsCode;
                formViewModel.IsPublished = frm.IsPublished;
                formViewModel.AddedBy = frm.AddedBy;
                formViewModel.AddedDate = frm.AddedDate;
                formViewModel.ModifiedBy = frm.ModifiedBy;
                formViewModel.ModifiedDate = frm.ModifiedDate;
                return View(formViewModel);
            }
            return RedirectToAction("Index");
      
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit(long id)
        {
            var frm = formService.GetForm(id);
            if (frm != null)
            {
                var formViewModel = new FormViewModel();
                formViewModel.Id = frm.Id;
                formViewModel.FormName = frm.FormName;
                formViewModel.Description = frm.Description;
                formViewModel.ClosingDescription = frm.ClosingDescription;
                formViewModel.EmailTo = frm.EmailTo;
                formViewModel.EmailCc = frm.EmailCc;
                formViewModel.EmailBcc = frm.EmailBcc;
                formViewModel.FormFields = frm.FormFields;
                formViewModel.GoogleAnalyticsCode = frm.GoogleAnalyticsCode;
                formViewModel.IsPublished = frm.IsPublished;
                formViewModel.AddedBy = frm.AddedBy;
                formViewModel.AddedDate = frm.AddedDate;
                formViewModel.ModifiedBy = frm.ModifiedBy;
                formViewModel.ModifiedDate = frm.ModifiedDate;
                ViewBag.Forms = new SelectList(formService.GetForms(), "Id", "FormName");
                ViewBag.FormFields = new SelectList(formFieldService.GetFormFields(), "Id", "Name");
                return View(formViewModel);
            }   
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormViewModel form)
        {
            
            if (ModelState.IsValid)
            {
                var frm = formService.GetForm(form.Id);
                frm.Id = form.Id;
                frm.FormName = form.FormName;
                frm.Description = form.Description;
                frm.ClosingDescription = form.ClosingDescription;
                frm.EmailTo = form.EmailTo;
                frm.EmailCc = form.EmailCc;
                frm.EmailBcc = form.EmailBcc;

                frm.GoogleAnalyticsCode = form.GoogleAnalyticsCode;
                frm.IsPublished = form.IsPublished;
                formService.UpdateForm(frm);
                formService.SaveForm();
                return RedirectToAction("Index");
            }
            ViewBag.Forms = new SelectList(formService.GetForms(), "Id", "FormName");
            ViewBag.FormFields = new SelectList(formFieldService.GetFormFields(), "Id", "Name");
            return View(form);
        }

        public ActionResult Delete(long id)
        {                            
            formService.DeleteForm(id);
            formService.SaveForm();
            return RedirectToAction("Index");
        }
        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {

            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var sortColumnIndex = Convert.ToInt32(Request.Query["iSortCol_0"]);
            var sortDirection = Request.Query["sSortDir_0"]; // asc or desc
            int iTotalRecords;
            int iTotalDisplayRecords;
            var displayedForms = formService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);
            var result = from c in displayedForms
                         select new[] {
                             c.Id.ToString(),
                             c.Id.ToString(),
                             c.FormName.ToString(),
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
