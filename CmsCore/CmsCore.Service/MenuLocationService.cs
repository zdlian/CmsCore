using CmsCore.Data.Infrastructure;
using CmsCore.Data.Repositories;
using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Service
{
    public interface IMenuLocationService
    {
        IEnumerable<MenuLocation> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
        IEnumerable<MenuLocation> GetMenuLocations();
        MenuLocation GetMenuLocation(long id);
        void CreateMenuLocation(MenuLocation menuLocation);
        void UpdateMenuLocation(MenuLocation menuLocation);
        void DeleteMenuLocation(long id);
        void SaveMenuLocation();

    }

    public class MenuLocationService : IMenuLocationService
    {
        private readonly IMenuLocationRepository menuLocationRepository;
        private readonly IUnitOfWork unitOfWork;
        public MenuLocationService(IMenuLocationRepository menuLocationRepository, IUnitOfWork unitOfWork)
        {
            this.menuLocationRepository = menuLocationRepository;
            this.unitOfWork = unitOfWork;
        }
        #region IMenuLocationServiceMembers
        public IEnumerable<MenuLocation> GetMenuLocations()
        {
            var menuLocations = menuLocationRepository.GetAll();
            return menuLocations;
        }
        public MenuLocation GetMenuLocation(long id)
        {
            var menuLocation = menuLocationRepository.GetById(id);
            return menuLocation;
        }
        public void CreateMenuLocation(MenuLocation menuLocation)
        {
            menuLocationRepository.Add(menuLocation);
        }
        public void UpdateMenuLocation(MenuLocation menuLocation)
        {
            menuLocationRepository.Update(menuLocation);
        }
        public void DeleteMenuLocation(long id)
        {
            menuLocationRepository.Delete(x => x.Id == id);
        }
        public void SaveMenuLocation()
        {
            unitOfWork.Commit();
        }
        public IEnumerable<MenuLocation> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            var menuLocations = menuLocationRepository.Search(search, sortColumnIndex, sortDirection, displayStart, displayLength, out totalRecords, out totalDisplayRecords);
            return menuLocations;
        }
    }
}
#endregion