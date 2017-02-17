using CmsCore.Data.Infrastructure;
using CmsCore.Data.Repositories;
using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Service
{
    public interface ISectionService
    {
        IEnumerable<Section> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
        IEnumerable<Section> GetSections();
        Section GetSection(long id);
        void CreateSection(Section section);
        void UpdateSection(Section section);
        void DeleteSection(long id);
        void SaveSection();

    }

    public class SectionService : ISectionService
    {
        private readonly ISectionRepository sectionRepository;
        private readonly IUnitOfWork unitOfWork;
        public SectionService(ISectionRepository sectionRepository, IUnitOfWork unitOfWork)
        {
            this.sectionRepository = sectionRepository;
            this.unitOfWork = unitOfWork;
        }
        #region ISectionServiceMembers
        public IEnumerable<Section> GetSections()
        {
            var sections = sectionRepository.GetAll();
            return sections;
        }
        public Section GetSection(long id)
        {
            var section = sectionRepository.GetById(id);
            return section;
        }
        public void CreateSection(Section section)
        {
            sectionRepository.Add(section);
        }
        public void UpdateSection(Section section)
        {
            sectionRepository.Update(section);
        }
        public void DeleteSection(long id)
        {
            sectionRepository.Delete(x => x.Id == id);
        }
        public void SaveSection()
        {
            unitOfWork.Commit();
        }
        public IEnumerable<Section> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            var sections = sectionRepository.Search(search, sortColumnIndex, sortDirection, displayStart, displayLength, out totalRecords, out totalDisplayRecords);
            return sections;
        }
    }
}
#endregion