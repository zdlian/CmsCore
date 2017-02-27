using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CmsCore.Service;
using CmsCore.Model.Entities;
using CmsCore.Admin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CmsCore.Admin.Controllers
{
    public class PostController : BaseController
    {
        private readonly IPostService postService;
        private readonly IPostCategoryService postCategoryService;
        public PostController(IPostService postService, IPostCategoryService postCategoryService)
        {
            this.postService = postService;
            this.postCategoryService = postCategoryService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var posts = postService.GetPosts();
            return View(posts);
        }

        public IActionResult Create()
        {
            ViewBag.PostCategories = postCategoryService.GetParentPostCategories();
            var postVM = new PostViewModel();
            return View(postVM);
        }
        [HttpPost]
        public IActionResult Create(PostViewModel postVM)
        {

            if (ModelState.IsValid)
            {
                Post post = new Post();
                post.Title = postVM.Title;
                post.Slug = postVM.Slug;
                post.Body = postVM.Body;
                post.IsPublished = postVM.IsPublished;
                post.PostPostCategories = postVM.PostPostCategories;
                post.SeoTitle = postVM.SeoTitle;
                post.SeoKeywords = postVM.SeoKeywords;
                post.SeoDescription = postVM.SeoDescription;
                post.PostPostCategories.Clear();
                if (postVM.PostCategoryId != null)
                { 
                    foreach (var item in postVM.PostCategoryId)
                    {
                        post.PostPostCategories.Add(new PostPostCategory { PostId = postVM.Id, PostCategoryId = item });
                    }
                }
                postService.CreatePost(post);
                postService.SavePost();
                return RedirectToAction("Index", "Post");
            }
            ViewBag.PostCategories = postCategoryService.GetParentPostCategories();
            return View(postVM);
        }

        public IActionResult Edit(long id)
        {
            var post = postService.GetPost(id);

            
            PostViewModel postVM = new PostViewModel();
            postVM.Id = post.Id;
            postVM.Title = post.Title;
            postVM.Slug = post.Slug;
            postVM.Body = post.Body;
            postVM.IsPublished = post.IsPublished;
            postVM.PostPostCategories = post.PostPostCategories;
            postVM.ModifiedDate = post.ModifiedDate;
            postVM.ModifiedBy = post.ModifiedBy;
            postVM.AddedBy = post.AddedBy;
            postVM.AddedDate = post.AddedDate;
            postVM.SeoTitle = post.SeoTitle;
            postVM.SeoDescription = post.SeoDescription;
            postVM.SeoKeywords = post.SeoKeywords;
            ViewBag.PostCategories = postCategoryService.GetParentPostCategories();
            postVM.PostCategoryId = new long[post.PostPostCategories.Count()];
            long index = 0;
            foreach (var item in post.PostPostCategories)
            {
                postVM.PostCategoryId[index] = item.PostCategoryId;
                index++;
            }
            return View(postVM);
        }

        [HttpPost]
        public IActionResult Edit(PostViewModel postVM)
        {
            if (ModelState.IsValid)
            {
                Post post = postService.GetPost(postVM.Id);
                
                post.Title = postVM.Title;
                post.Slug = postVM.Slug;
                post.Body = postVM.Body;
                post.IsPublished = postVM.IsPublished;
                post.PostPostCategories.Clear();
                foreach (var item in postVM.PostCategoryId)
                {
                    post.PostPostCategories.Add(new PostPostCategory { PostId = postVM.Id, PostCategoryId = item });
                }
                post.SeoTitle = postVM.SeoTitle;
                post.SeoDescription = postVM.SeoDescription;
                post.SeoKeywords = postVM.SeoKeywords;
                postService.UpdatePost(post);
                postService.SavePost();
                return RedirectToAction("Index", "Post");
            }
            ViewBag.PostCategories = postCategoryService.GetParentPostCategories();
           
            return View(postVM);
        }

        public IActionResult Delete(long id)
        {
            postService.DeletePost(id);
            postService.SavePost();
            return RedirectToAction("Index", "Post");
        }

        public ActionResult Details(int id)
        {
            var post = postService.GetPost(id);
            return View(post);
        }

        public static string RenderPostCategories(IEnumerable<PostCategory> categories, long[] selectedIds)
        {
            string result = "";
            if (selectedIds == null)
            {
                selectedIds = new long[0];
            }
            foreach (var category in categories)
            {

                result += "{ \"text\": \"" + category.Name + "\", \"state\": { \"selected\": " + (selectedIds.Contains(category.Id) ? "false" : "false") + " }, ";

                if (category.ChildCategories.Count() > 0)
                {
                    result += "\"children\": [" + RenderPostCategories(category.ChildCategories, selectedIds) + "],},";
                }
                else
                {
                    result += "},";
                }
            }

            return result;
        }

        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var sortColumnIndex = Convert.ToInt32(Request.Query["iSortCol_0"]);
            var sortDirection = Request.Query["sSortDir_0"]; // asc or desc
            int iTotalRecords;
            int iTotalDisplayRecords;
            var displayedPosts = postService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);

            var result = from p in displayedPosts
                         select new[] { p.Id.ToString(), p.Title.ToString(), p.AddedBy.ToString(), p.ViewCount.ToString(), p.ModifiedDate.ToString(), string.Empty };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = iTotalRecords,
                iTotalDisplayRecords = iTotalDisplayRecords,
                aaData = result.ToList()
            });
        }
    }
}
