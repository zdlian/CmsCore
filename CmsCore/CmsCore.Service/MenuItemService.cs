using CmsCore.Data.Infrastructure;
using CmsCore.Data.Repositories;
using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Service
{
    public interface IMenuItemService
    {
        IEnumerable<MenuItem> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
        IEnumerable<MenuItem> GetMenuItems();
        MenuItem GetMenuItem(long id);
        void CreateMenuItem(MenuItem menuItem);
        void UpdateMenuItem(MenuItem menuItem);
        void DeleteMenuItem(long id);
        void SaveMenuItem();

    }

    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository menuItemRepository;
        private readonly IUnitOfWork unitOfWork;
        public MenuItemService(IMenuItemRepository menuItemRepository, IUnitOfWork unitOfWork)
        {
            this.menuItemRepository = menuItemRepository;
            this.unitOfWork = unitOfWork;
        }
        #region IMenuItemServiceMembers
        public IEnumerable<MenuItem> GetMenuItems()
        {
            var menuItems = menuItemRepository.GetAll();
            return menuItems;
        }
        public MenuItem GetMenuItem(long id)
        {
            var menuItem = menuItemRepository.GetById(id);
            return menuItem;
        }
        public void CreateMenuItem(MenuItem menuItem)
        {
            menuItemRepository.Add(menuItem);
        }
        public void UpdateMenuItem(MenuItem menuItem)
        {
            menuItemRepository.Update(menuItem);
        }
        public void DeleteMenuItem(long id)
        {
            menuItemRepository.Delete(x => x.Id == id);
        }
        public void SaveMenuItem()
        {
            unitOfWork.Commit();
        }
        public IEnumerable<MenuItem> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            var menuItems = menuItemRepository.Search(search, sortColumnIndex, sortDirection, displayStart, displayLength, out totalRecords, out totalDisplayRecords);
            return menuItems;
        }
    }
    #endregion
}
