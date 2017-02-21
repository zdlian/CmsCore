using CmsCore.Data.Infrastructure;
using CmsCore.Data.Repositories;
using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Service
{
    public interface ISettingService
    {
        IEnumerable<Setting> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
        IEnumerable<Setting> GetSettings();
        Setting GetSetting(long id);
        Setting GetSettingByName(string name);
        void CreateSetting(Setting setting);
        void UpdateSetting(Setting setting);
        void DeleteSetting(long id);
        void SaveSetting();

    }

    public class SettingService : ISettingService
    {
        private readonly ISettingRepository settingRepository;
        private readonly IUnitOfWork unitOfWork;
        public SettingService(ISettingRepository settingRepository, IUnitOfWork unitOfWork)
        {
            this.settingRepository = settingRepository;
            this.unitOfWork = unitOfWork;
        }
        #region ISettingServiceMembers
        public IEnumerable<Setting> GetSettings()
        {
            var settings = settingRepository.GetAll();
            return settings;
        }
        public Setting GetSettingByName(string name)
        {
            var settings = settingRepository.GetSettingByName(name);
            return settings; }
        public Setting GetSetting(long id)
        {
            var setting = settingRepository.GetById(id);
            return setting;
        }
        public void CreateSetting(Setting setting)
        {
            settingRepository.Add(setting);
        }
        public void UpdateSetting(Setting setting)
        {
            settingRepository.Update(setting);
        }
        public void DeleteSetting(long id)
        {
            settingRepository.Delete(x => x.Id == id);
        }
        public void SaveSetting()
        {
            unitOfWork.Commit();
        }
        public IEnumerable<Setting> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            var settings = settingRepository.Search(search, sortColumnIndex, sortDirection, displayStart, displayLength, out totalRecords, out totalDisplayRecords);
            return settings;
        }
    }
}
#endregion