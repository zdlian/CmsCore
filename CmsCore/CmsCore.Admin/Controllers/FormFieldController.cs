using CmsCore.Admin.Models;
using CmsCore.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Admin.Controllers
{
    public class FormFieldController : BaseController
    {
        private readonly IFormService formService;
        private readonly IFormFieldService formFieldService;
        public FormFieldController(FormService formService, FormFieldService formFieldService)
        {
            this.formService = formService;
            this.formFieldService = formFieldService;
        }
        public IActionResult Create(long id)
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(FormFieldViewModel formField)
        {

            return View();

        }
        public IActionResult Details(long id)
        {

            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Edit(long id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FormFieldViewModel formField)
        {
            ViewBag.Forms = new SelectList(formService.GetForms(), "FormId", "FormName");
            ViewBag.FormFieldId = new SelectList(formFieldService.GetFormFields(), "FormFieldId", "Description");


            return View(formField);
        }

        public IActionResult Delete(long id)
        {

            return RedirectToAction("Index");
        }

    
        public IActionResult AjaxHandler(jQueryDataTableParamModel param)
        {

            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var sortColumnIndex = Convert.ToInt32(Request.Query["iSortCol_0"]);
            var sortDirection = Request.Query["sSortDir_0"]; // asc or desc
            int iTotalRecords;
            int iTotalDisplayRecords;
            var displayedForms = formFieldService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);
            var result = from c in displayedForms
                         select new[] {
                             c.Id.ToString(),
                             c.Name.ToString(),
                             c.FieldType.ToString(),
                             c.Required.ToString(),
                             c.Form.FormName.ToString(),
                             string.Empty };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = iTotalRecords,
                iTotalDisplayRecords = iTotalDisplayRecords,
                aaData = result.ToList()
            });
        }

        public void UpdateFormFieldPosition(string position1, string text1, string position2, string text2, string Id)
        {
            var fields = formService.GetFormFieldsByFormId(Convert.ToInt32(Id));
            foreach (var item in fields)
            {
                //if (item.Description == text2)
                //{
                //    item.Position = Convert.ToInt32(position1);
                //    formFieldService.UpdateFormField(item);
                //    formFieldService.SaveFormField();
                //}
                //if (item.Description == text1)
                //{
                //    item.Position = Convert.ToInt32(position2);
                //    formFieldService.UpdateFormField(item);
                //    formFieldService.SaveFormField();
                }

            }
        }
    }

