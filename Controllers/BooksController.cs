using BooklyProject.Context;
using BooklyProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooklyProject.Controllers
{
    
    public class BooksController : Controller
    {
        BooklyContext context = new BooklyContext();
        public ActionResult Index(string searchText)
        {
            List<Book> values;

            if (searchText != null)
            {
                values = context.Books.Where(x => x.BookName.Contains(searchText)).ToList();
                return View(values);
            }


            values = context.Books.ToList();
            return View(values);
        }

        public ActionResult DeleteBook(int id)
        {
            var values = context.Books.Find(id);
            context.Books.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddBook()
        {
            var authors = context.Authors
                .Select(x => new
                {
                    x.AuthorId,
                    FullName = x.Name + " " + x.Surname
                })
                .ToList();

            ViewBag.Authors = new SelectList(authors, "AuthorId", "FullName");
            return View();
        }

        [HttpPost]
        public ActionResult AddBook(Book model)
        {
            if (ModelState.IsValid)
            {
                context.Books.Add(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            // Eğer hata olursa yazar listesini tekrar yükle
            var authors = context.Authors
                .Select(x => new
                {
                    x.AuthorId,
                    FullName = x.Name + " " + x.Surname
                })
                .ToList();

            ViewBag.Authors = new SelectList(authors, "AuthorId", "FullName");

            return View(model);
        }

        [HttpGet]
        public ActionResult UpdateBook(int id)
        {
            // Kitap verisini id'ye göre bul
            var values = context.Books.Find(id);

            // Yazarları al
            var authors = context.Authors
                .Select(x => new
                {
                    x.AuthorId,
                    FullName = x.Name + " " + x.Surname
                })
                .ToList();

           

            ViewBag.Authors = new SelectList(authors, "AuthorId", "FullName", values.AuthorId);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateBook(Book model)
        {
            if (ModelState.IsValid)
            {
                var value = context.Books.Find(model.BookId);
                if (value != null)
                {
                    // Kitap bilgilerini güncelle
                    value.BookName = model.BookName;
                    value.CoverImageUrl = model.CoverImageUrl;
                    value.AuthorId = model.AuthorId;
                    value.Price = model.Price;
                    value.Review = model.Review;
                    value.DiscountRate = model.DiscountRate;
                    value.IsOnSale = model.IsOnSale;

                    // Değişiklikleri kaydet
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            // Hata durumunda yazarları tekrar listele ve ViewBag'e gönder
            var authors = context.Authors
                .Select(x => new
                {
                    x.AuthorId,
                    FullName = x.Name + " " + x.Surname
                })
                .ToList();

            // ViewBag.Authors ile yazarları güncelle
            ViewBag.Authors = new SelectList(authors, "AuthorId", "FullName", model.AuthorId);

            // Modeli geri gönder, formu tekrar göster
            return View(model);
        }

    }
}