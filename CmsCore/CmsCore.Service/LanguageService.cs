using CmsCore.Data.Infrastructure;
using CmsCore.Data.Repositories;
using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Service
{
    public interface ILanguageService
    {
        IEnumerable<Language> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
        IEnumerable<Language> GetLanguages();
        Language GetLanguage(long id);
        void CreateLanguage(Language language);
        void UpdateLanguage(Language language);
        void DeleteLanguage(long id);
        void SaveLanguage();

    }

    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepository languageRepository;
        private readonly IUnitOfWork unitOfWork;
        public LanguageService(ILanguageRepository languageRepository, IUnitOfWork unitOfWork)
        {
            this.languageRepository = languageRepository;
            this.unitOfWork = unitOfWork;
        }
        #region ILanguageServiceMembers
        public IEnumerable<Language> GetLanguages()
        {
            var languages = languageRepository.GetAll();
            return languages;
        }
        public Language GetLanguage(long id)
        {
            var language = languageRepository.GetById(id);
            return language;
        }
        public void CreateLanguage(Language language)
        {
            languageRepository.Add(language);
        }
        public void UpdateLanguage(Language language)
        {
            languageRepository.Update(language);
        }
        public void DeleteLanguage(long id)
        {
            languageRepository.Delete(x => x.Id == id);
        }
        public void SaveLanguage()
        {
            unitOfWork.Commit();
        }
        public IEnumerable<Language> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            var languages = languageRepository.Search(search, sortColumnIndex, sortDirection, displayStart, displayLength, out totalRecords, out totalDisplayRecords);
            return languages;
        }
    }
}
#endregion