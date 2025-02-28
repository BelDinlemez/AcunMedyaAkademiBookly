using BooklyProject.Context;
using BooklyProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooklyProject.Controllers
{
    
    public class PhotoGalleryController : Controller
    {
        BooklyContext context = new BooklyContext();
        public ActionResult Index()
        {
            var values = context.PhotoGalleries.ToList();
            return View(values);
        }

        public ActionResult DeletePhoto(int id)
        {
            var values = context.PhotoGalleries.Find(id);
            context.PhotoGalleries.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddPhoto()
        {
            return View();

        }

        [HttpPost]
        public ActionResult AddPhoto(PhotoGallery model)
        {
            context.PhotoGalleries.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult UpdatePhoto(int id)
        {
            var value = context.PhotoGalleries.Find(id);
            return View(value);

        }
        [HttpPost]
        public ActionResult UpdatePhoto(PhotoGallery model)
        {
            var value = context.PhotoGalleries.Find(model.PhotoGalleryId);
            value.ImageUrl = model.ImageUrl;
            value.IsShown = model.IsShown;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}