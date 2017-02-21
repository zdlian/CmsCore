using CmsCore.Data.Infrastructure;
using CmsCore.Data.Repositories;
using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Service
{
    public interface IRedirectService
    {
        IEnumerable<Redirect> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
        IEnumerable<Redirect> GetRedirects();
        Redirect GetRedirect(long id);
        void CreateRedirect(Redirect redirect);
        void UpdateRedirect(Redirect redirect);
        void DeleteRedirect(long id);
        void SaveRedirect();

    }

    public class RedirectService : IRedirectService
    {
        private readonly IRedirectRepository redirectRepository;
        private readonly IUnitOfWork unitOfWork;
        public RedirectService(IRedirectRepository redirectRepository, IUnitOfWork unitOfWork)
        {
            this.redirectRepository = redirectRepository;
            this.unitOfWork = unitOfWork;
        }
        #region IRedirectServiceMembers
        public IEnumerable<Redirect> GetRedirects()
        {
            var redirects = redirectRepository.GetAll();
            return redirects;
        }
        public Redirect GetRedirect(long id)
        {
            var redirect = redirectRepository.GetById(id);
            return redirect;
        }
        public void CreateRedirect(Redirect redirect)
        {
            redirectRepository.Add(redirect);
        }
        public void UpdateRedirect(Redirect redirect)
        {
            redirectRepository.Update(redirect);
        }
        public void DeleteRedirect(long id)
        {
            redirectRepository.Delete(x => x.Id == id);
        }
        public void SaveRedirect()
        {
            unitOfWork.Commit();
        }
        public IEnumerable<Redirect> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            var redirects = redirectRepository.Search(search, sortColumnIndex, sortDirection, displayStart, displayLength, out totalRecords, out totalDisplayRecords);
            return redirects;
        }
    }
}
#endregion