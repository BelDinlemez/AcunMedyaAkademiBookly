using BooklyProject.Context;
using BooklyProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooklyProject.Controllers
{
   
    public class BookCategoryController : Controller
    {
        BooklyContext context = new BooklyContext();
        public ActionResult Index()
        {
            var values = context.BookCategories.ToList();
            return View(values);
        }

        public ActionResult DeleteBookCategory(int id)
        {
            var values = context.BookCategories.Find(id);
            context.BookCategories.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddBookCategory()
        {
            return View();

        }

        [HttpPost]
        public ActionResult AddBookCategory(BookCategory model)
        {
            context.BookCategories.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult UpdateBookCategory(int id)
        {
            var value = context.BookCategories.Find(id);
            return View(value);

        }
        [HttpPost]
        public ActionResult UpdateBookCategory(BookCategory model)
        {
            var value = context.BookCategories.Find(model.BookCategoryId);
            value.BookId = model.BookId;
            value.CategoryId = model.CategoryId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}