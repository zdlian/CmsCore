using CmsCore.Admin.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;
using CmsCore.Model.Entities;
using CmsCore.Service;

namespace CmsCore.Admin.Controllers
{
    public class MediaController:BaseController
    {
        private readonly IMediaService mediaService;

        public MediaController(IMediaService mediaService) {
            this.mediaService = mediaService; }
        public IActionResult Index() {
            var medias = mediaService.GetMedias();
            return View(medias);
        }
        public IActionResult Create() {
           
            return View();
            
        }
        [HttpPost]
        public IActionResult Create(MediaViewModel mediaVM, IFormFile uploadedFile)
        {
            if (ModelState.IsValid)
            {
                if (uploadedFile != null){
                Media media = new Media();
                media.Title = mediaVM.Title;
                media.FileName = uploadedFile.FileName;
                media.Description = mediaVM.Description;
                media.Size = mediaVM.Size;
                media.AddedBy = "Cevdet";
                media.AddedDate = DateTime.Now;
                media.ModifiedBy = "CEVDET";
                media.ModifiedDate = DateTime.Now;
                    if (Path.GetExtension(uploadedFile.FileName) == ".doc"
                    || Path.GetExtension(uploadedFile.FileName) == ".pdf"
                    || Path.GetExtension(uploadedFile.FileName) == ".rtf"
                    || Path.GetExtension(uploadedFile.FileName) == ".docx"
                    || Path.GetExtension(uploadedFile.FileName) == ".jpg"
                    || Path.GetExtension(uploadedFile.FileName) == ".gif"
                    || Path.GetExtension(uploadedFile.FileName) == ".png"
                     )
                    {
                        string FilePath = ViewBag.UploadPath + "\\media\\";
                        string dosyaYolu = Path.GetFileName(uploadedFile.FileName);
                        var yuklemeYeri = Path.Combine(FilePath + dosyaYolu);
                        try
                        {
                            if (!Directory.Exists(FilePath))
                            {
                                Directory.CreateDirectory(FilePath);//Eğer klasör yoksa oluştur
                                uploadedFile.CopyTo(new FileStream(yuklemeYeri, FileMode.Create));
                            }
                            else
                            {
                                uploadedFile.CopyTo(new FileStream(yuklemeYeri, FileMode.Create));
                            }
                            mediaService.CreateMedia(media);
                            mediaService.SaveMedia();
                            return RedirectToAction("Index");
                        }
                        catch (Exception) { }
                    }
                    else
                    {
                        ModelState.AddModelError("FileName", "Dosya uzantısı izin verilen uzantılardan olmalıdır.");
                    }
                } 
            else { ModelState.AddModelError("FileExist", "Lütfen bir dosya seçiniz!"); }
            }
             return View(mediaVM);
        }
        public IActionResult Edit(long id)
        {
            var media = mediaService.GetMedia(id);
            MediaViewModel mediaVM = new MediaViewModel();
            mediaVM.Id = media.Id;
            mediaVM.Title = media.Title;
            mediaVM.Description = media.Description;
            mediaVM.FileName = media.FileName;
            mediaVM.ModifiedDate = media.ModifiedDate;
            mediaVM.ModifiedBy = media.ModifiedBy;
            mediaVM.AddedBy = media.AddedBy;
            mediaVM.AddedDate = media.AddedDate;
           
            return View(mediaVM);
        }

        [HttpPost]
        public IActionResult Edit(Media media, IFormFile uploadedFile)
        {
            if (ModelState.IsValid)
            {
                if (uploadedFile != null)
                {
                    
                    media.ModifiedBy = User.Identity.Name??"CEVDET";
                    media.ModifiedDate = DateTime.Now;
                    if (Path.GetExtension(uploadedFile.FileName) == ".doc"
                    || Path.GetExtension(uploadedFile.FileName) == ".pdf"
                    || Path.GetExtension(uploadedFile.FileName) == ".rtf"
                    || Path.GetExtension(uploadedFile.FileName) == ".docx"
                    || Path.GetExtension(uploadedFile.FileName) == ".jpg"
                    || Path.GetExtension(uploadedFile.FileName) == ".gif"
                    || Path.GetExtension(uploadedFile.FileName) == ".png"
                     )
                    {
                        string FilePath = ViewBag.UploadPath + "\\media\\";
                        string dosyaYolu = Path.GetFileName(uploadedFile.FileName);
                        var yuklemeYeri = Path.Combine(FilePath + dosyaYolu);
                        try
                        {
                            if (!Directory.Exists(FilePath))
                            {
                                Directory.CreateDirectory(FilePath);//Eğer klasör yoksa oluştur
                                uploadedFile.CopyTo(new FileStream(yuklemeYeri, FileMode.Create));
                            }
                            else
                            {
                                uploadedFile.CopyTo(new FileStream(yuklemeYeri, FileMode.Create));
                                media.FileName = uploadedFile.FileName;
                            }
                            mediaService.UpdateMedia(media);
                            mediaService.SaveMedia();
                            return RedirectToAction("Index");
                        }
                        catch (Exception) { }
                    }
                    else
                    {
                        ModelState.AddModelError("FileName", "Dosya uzantısı izin verilen uzantılardan olmalıdır.");
                    }
                }
                else { ModelState.AddModelError("FileExist", "Lütfen bir dosya seçiniz!"); }
            }
            return View(media);
        }

        public IActionResult Delete(long id)
        {
            mediaService.DeleteMedia(id);
            mediaService.SaveMedia();
            return RedirectToAction("Index", "Media");
        }

       
        public IActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var sortColumnIndex = Convert.ToInt32(Request.Query["iSortCol_0"]);
            var sortDirection = Request.Query["sSortDir_0"]; // asc or desc
            int iTotalRecords;
            int iTotalDisplayRecords;
            var displayedPages = mediaService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);

            var result = from p in displayedPages
                         select new[] {
                             p.Id.ToString(),
                             p.FileName.ToString(),
                             p.AddedBy.ToString(),
                             p.AddedDate.ToString(),
                             string.Empty };
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
