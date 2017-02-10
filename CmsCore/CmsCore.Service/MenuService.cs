using CmsCore.Data.Infrastructure;
using CmsCore.Data.Repositories;
using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Service
{
    public interface IMenuService {
        IEnumerable<Menu> GetMenus();
        Menu GetMenu(long id);
        void CreateMenu(Menu menu);
        void UpdateMenu(Menu menu);
        void DeleteMenu(long id);
        void SaveMenu();

    }

    public class MenuService:IMenuService
    {
        private readonly IMenuRepository menuRepository;
        private readonly IUnitOfWork unitOfWork;
        public MenuService(IMenuRepository menuRepository,IUnitOfWork unitOfWork)
        {
            this.menuRepository = menuRepository;
            this.unitOfWork = unitOfWork;
        }
        #region IMenuServiceMembers
        public IEnumerable<Menu> GetMenus() {
            var menus = menuRepository.GetAll();
            return menus;
        }
        public Menu GetMenu(long id) {
            var menu = menuRepository.GetById(id);
            return menu;
        }
        public void CreateMenu(Menu menu) {
            menuRepository.Add(menu);
        }
        public void UpdateMenu(Menu menu)
        {
            menuRepository.Update(menu);
        }
        public void DeleteMenu(long id)
        {
            menuRepository.Delete(x=>x.Id==id);
        }
        public void SaveMenu()
        {
           unitOfWork.Commit();
        }
    }
}
#endregion