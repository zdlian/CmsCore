using CmsCore.Data.Infrastructure;
using CmsCore.Data.Repositories;
using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Service
{
    public interface IMediaService
    {
        IEnumerable<Media> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
        IEnumerable<Media> GetMedias();
        Media GetMedia(long id);
        void CreateMedia(Media media);
        void UpdateMedia(Media media);
        void DeleteMedia(long id);
        void SaveMedia();

    }

    public class MediaService : IMediaService
    {
        private readonly IMediaRepository mediaRepository;
        private readonly IUnitOfWork unitOfWork;
        public MediaService(IMediaRepository mediaRepository, IUnitOfWork unitOfWork)
        {
            this.mediaRepository = mediaRepository;
            this.unitOfWork = unitOfWork;
        }
        #region IMediaServiceMembers
        public IEnumerable<Media> GetMedias()
        {
            var medias = mediaRepository.GetAll();
            return medias;
        }
        public Media GetMedia(long id)
        {
            var media = mediaRepository.GetById(id);
            return media;
        }
        public void CreateMedia(Media media)
        {
            mediaRepository.Add(media);
        }
        public void UpdateMedia(Media media)
        {
            mediaRepository.Update(media);
        }
        public void DeleteMedia(long id)
        {
            mediaRepository.Delete(x => x.Id == id);
        }
        public void SaveMedia()
        {
            unitOfWork.Commit();
        }
        public IEnumerable<Media> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            var medias = mediaRepository.Search(search, sortColumnIndex, sortDirection, displayStart, displayLength, out totalRecords, out totalDisplayRecords);
            return medias;
        }
    }
}
#endregion