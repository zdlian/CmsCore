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
    public class MenuController : Controller
    {
        private readonly IMenuService menuService;
        public MenuController(IMenuService menuService) {
            this.menuService = menuService;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
          
            return View();
        }
        public IActionResult Create() {
            var menu = new Menu();
            return View(menu);

        }
        [HttpPost]
        public IActionResult Create(Menu menu) {
            if (ModelState.IsValid)
            {
                menuService.CreateMenu(menu);
                menuService.SaveMenu();
                return RedirectToAction("Index", "Menu");
            }
            return View(menu);
        }
        public IActionResult Edit(long id) {
            var menu = menuService.GetMenu(id);
            return View(menu);
        }
        [HttpPost]
        public IActionResult Edit(Menu menu) {
            if (ModelState.IsValid)
            {
                menuService.UpdateMenu(menu);
                menuService.SaveMenu();
                return RedirectToAction("Index", "Menu");
            }
            return View(menu);
        }
        public IActionResult Delete(long id) {
            menuService.DeleteMenu(id);
            menuService.SaveMenu();
            return RedirectToAction("Index", "Menu");
        }
    }
}
