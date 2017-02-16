using CmsCore.Data.Infrastructure;
using CmsCore.Data.Repositories;
using CmsCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Service
{
    public interface IPostService
    {
        IEnumerable<Post> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
        IEnumerable<Post> GetPosts();
        Post GetPost(int id);

        void CreatePost(Post post);
        void UpdatePost(Post post);
        void DeletePost(Post post);
        Post GetPostBySlug(string Slug);
        void SavePost();
    }
    public class PostService : IPostService
    {
        private readonly IPostRepository postRepository;
        private readonly IUnitOfWork unitOfWork;
        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            this.postRepository = postRepository;
            this.unitOfWork = unitOfWork;
        }
        #region IPostService Members
        public IEnumerable<Post> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            var posts = postRepository.Search(search, sortColumnIndex, sortDirection, displayStart, displayLength, out totalRecords, out totalDisplayRecords);
            return posts;
        }
        public IEnumerable<Post> GetPosts()
        {
            var posts = postRepository.GetAll().OrderByDescending(p => p.AddedDate);
            return posts;
        }

        public Post GetPost(int id)
        {
            var post = postRepository.GetById(id);
            return post;
        }


        public void CreatePost(Post post)
        {
            postRepository.Add(post);
        }
        public void UpdatePost(Post post)
        {
            postRepository.Update(post);
        }
        public void DeletePost(Post post)
        {
            postRepository.Delete(post);
        }

        public Post GetPostBySlug(string Slug)
        {
            return postRepository.GetPostBySlug(Slug);
        }


        public void SavePost()
        {
            unitOfWork.Commit();
        }


        #endregion
    }
}
