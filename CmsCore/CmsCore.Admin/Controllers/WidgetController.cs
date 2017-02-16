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
    public class WidgetController : BaseController
    {
        private readonly IWidgetService widgetService;
       
        public WidgetController(IWidgetService widgetService)
        {
            this.widgetService = widgetService;
           
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            var widget = new Widget();
           // ViewBag.Widgets = new SelectList(widgetService.GetWidgets(), "Id", "Name", widget.WidgetId);
            return View(widget);

        }
        [HttpPost]
        public IActionResult Create(WidgetViewModel widgetVM)
        {
            if (ModelState.IsValid)
            {
                Widget widget = new Widget();
           
                widgetService.CreateWidget(widget);
                widgetService.SaveWidget();
                return RedirectToAction("Index", "Widget");
            }
          ViewBag.Widgets = new SelectList(widgetService.GetWidgets(), "Id", "Name", widgetVM.Id);
            return View(widgetVM);
        }
        public IActionResult Edit(long id)
        {
         //   ViewBag.Widgets = new SelectList(widgetService.GetWidgets(), "Id", "Name");
            var widget = widgetService.GetWidget(id);
            return View(widget);
        }
        [HttpPost]
        public IActionResult Edit(Widget widget)
        {
            if (ModelState.IsValid)
            {
             //   widget.Widget = widgetService.GetWidget(widget.WidgetId.Value);
                widgetService.UpdateWidget(widget);
                widgetService.SaveWidget();
                return RedirectToAction("Index", "Widget");
            }
           // ViewBag.Widgets = new SelectList(widgetService.GetWidgets(), "Id", "Name", widget.WidgetId);
            return View(widget);
        }
        public IActionResult Delete(long id)
        {
            widgetService.DeleteWidget(id);
            widgetService.SaveWidget();
            return RedirectToAction("Index", "Widget");
        }
        public IActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var sortColumnIndex = Convert.ToInt32(Request.Query["iSortCol_0"]);
            var sortDirection = Request.Query["sSortDir_0"]; // asc or desc
            int iTotalRecords;
            int iTotalDisplayRecords;
            var displayedPages = widgetService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);

            var result = from p in displayedPages
                         select new[]{
                             p.Id.ToString(),
                             p.Id.ToString(),
                             p.Name.ToString(),
                             p.Action.ToString(),
                             p.Params.ToString(),
                             p.Description.ToString(),
                             p.IsTemplate.ToString(),
                             p.SideBar.ToString(),
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
        //GET: Widget

        public IActionResult WidgetIndex()
        {
            return View();
        }
        public IActionResult WidgetCreate()
        {
            var widget = new Widget();
            return View(widget);
        }
        [HttpPost]
        public IActionResult WidgetCreate(Widget widget)
        {
            if (ModelState.IsValid)
            {
                widgetService.CreateWidget(widget);
                widgetService.SaveWidget();
                return RedirectToAction("WidgetIndex", "Widget");
            }
            return View(widget);
        }
        public IActionResult WidgetEdit(long id)
        {
            var widget = widgetService.GetWidget(id);
            return View(widget);
        }
        [HttpPost]
        public IActionResult WidgetEdit(Widget widget)
        {
            if (ModelState.IsValid)
            {
                widgetService.UpdateWidget(widget);
                widgetService.SaveWidget();
                return RedirectToAction("WidgetIndex", "Widget");
            }
            return View(widget);
        }
        public IActionResult WidgetDelete(long id)
        {
            widgetService.DeleteWidget(id);
            widgetService.SaveWidget();
            return RedirectToAction("WidgetIndex", "Widget");
        }
        public IActionResult WidgetAjaxHandler(jQueryDataTableParamModel param)
        {
            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var sortColumnIndex = Convert.ToInt32(Request.Query["iSortCol_0"]);
            var sortDirection = Request.Query["sSortDir_0"]; // asc or desc
            int iTotalRecords;
            int iTotalDisplayRecords;
            var displayedWidgets = widgetService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);

            var result = from c in displayedWidgets
                         select new[]{
                             c.Id.ToString(),
                             c.Id.ToString(),
                             c.Name.ToString(),
                             string.Empty
                         };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = iTotalRecords,
                iTotalDisplayRecords = iTotalDisplayRecords,
                aaData = result
            });
        }
    }
}
