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
    public class MenuController : BaseController
    {
        private readonly IMenuService menuService;
        private readonly IMenuLocationService menuLocationService;
        public MenuController(IMenuService menuService,IMenuLocationService menuLocationService) {
            this.menuService = menuService;
            this.menuLocationService = menuLocationService;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create() {
            var menu = new Menu();
            ViewBag.MenuLocations = new SelectList(menuLocationService.GetMenuLocations(), "Id", "Name",menu.MenuLocationId);
            return View(menu);

        }
        [HttpPost]
        public IActionResult Create(Menu menu) {
            if (ModelState.IsValid){
                menu.MenuLocation = menuLocationService.GetMenuLocation(menu.MenuLocationId.Value);
                menuService.CreateMenu(menu);
                menuService.SaveMenu();
                return RedirectToAction("Index", "Menu");
            }
            ViewBag.MenuLocations = new SelectList(menuLocationService.GetMenuLocations(), "Id", "Name", menu.Id);
            return View(menu);
        }
        public IActionResult Edit(long id) {
            ViewBag.MenuLocations = new SelectList(menuLocationService.GetMenuLocations(), "Id", "Name");
            var menu = menuService.GetMenu(id);
            return View(menu);
        }
        [HttpPost]
        public IActionResult Edit(Menu menu) {
            if (ModelState.IsValid){
                menu.MenuLocation = menuLocationService.GetMenuLocation(menu.MenuLocationId.Value);
                menuService.UpdateMenu(menu);
                menuService.SaveMenu();
                return RedirectToAction("Index", "Menu");
            }
            ViewBag.MenuLocations = new SelectList(menuLocationService.GetMenuLocations(), "Id", "Name", menu.MenuLocationId);
            return View(menu);
        }
        public IActionResult Delete(long id) {
            menuService.DeleteMenu(id);
            menuService.SaveMenu();
            return RedirectToAction("Index", "Menu");
        }
        public IActionResult AjaxHandler(jQueryDataTableParamModel param){
            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var sortColumnIndex = Convert.ToInt32(Request.Query["iSortCol_0"]);
            var sortDirection = Request.Query["sSortDir_0"]; // asc or desc
            int iTotalRecords;
            int iTotalDisplayRecords;
            var displayedPages = menuService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);

            var result = from p in displayedPages
                         select new[]{
                             p.Id.ToString(),
                             p.Id.ToString(),
                             p.Name.ToString(),
                            (p.MenuLocationId.ToString()),
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
        //GET: MenuLocation

        public IActionResult MenuLocationIndex() {
            return View();
        }
        public IActionResult MenuLocationCreate() {
            var menuLocation = new MenuLocation();
            return View(menuLocation);
        }
        [HttpPost]
        public IActionResult MenuLocationCreate(MenuLocation menuLocation){
            if (ModelState.IsValid){
                menuLocationService.CreateMenuLocation(menuLocation);
                menuLocationService.SaveMenuLocation();
                return RedirectToAction("MenuLocationIndex", "Menu");
            }
            return View(menuLocation);
        }
        public IActionResult MenuLocationEdit(long id){
            var menuLocation = menuLocationService.GetMenuLocation(id);
            return View(menuLocation);
        }
        [HttpPost]
        public IActionResult MenuLocationEdit(MenuLocation menuLocation){
            if (ModelState.IsValid){
                menuLocationService.UpdateMenuLocation(menuLocation);
                menuLocationService.SaveMenuLocation();
                return RedirectToAction("MenuLocationIndex", "Menu");
            }
            return View(menuLocation);
        }
        public IActionResult MenuLocationDelete(long id){
            menuLocationService.DeleteMenuLocation(id);
            menuLocationService.SaveMenuLocation();
            return RedirectToAction("MenuLocationIndex", "Menu");
        }
        public IActionResult MenuLocationAjaxHandler(jQueryDataTableParamModel param){
            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var sortColumnIndex = Convert.ToInt32(Request.Query["iSortCol_0"]);
            var sortDirection = Request.Query["sSortDir_0"]; // asc or desc
            int iTotalRecords;
            int iTotalDisplayRecords;
            var displayedMenuLocations = menuLocationService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);

            var result = from c in displayedMenuLocations
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
