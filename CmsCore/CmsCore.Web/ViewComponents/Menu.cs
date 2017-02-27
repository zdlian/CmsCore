using CmsCore.Model.Entities;
using CmsCore.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Web.ViewComponents
{
    public class Menu:ViewComponent
    {
        private readonly IMenuService menuService;
        private readonly IMenuItemService menuItemService;
        public Menu(IMenuService menuService, IMenuItemService menuItemService)
        {
            this.menuService = menuService;
            this.menuItemService = menuItemService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string menuLocation)
        {
            
            var items = GetItems(menuLocation);
            return View(items);
        }
        private List<MenuItem> GetItems(string menuLocation)
        {
            CmsCore.Model.Entities.Menu menu = menuService.GetMenuByLocationName(menuLocation);
            return menu.MenuItems.ToList();
        }
    }
}
