using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CmsCore.Service;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CmsCore.Admin.Controllers
{
    public class MenusController : Controller
    {
        private readonly IMenuService menuService;
        public MenusController(IMenuService menuService) {
            this.menuService = menuService;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var menus = menuService.GetMenus();
            return View(menus);
        }
    }
}
