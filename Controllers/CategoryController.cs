﻿using BooklyProject.Context;
using BooklyProject.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooklyProject.Controllers
{

    public class CategoryController : Controller
    {
        BooklyContext context=new BooklyContext();  
        // GET: Category
        public ActionResult Index()
        {
            var values =context.Categories.ToList();
            return View(values);
        }

        public ActionResult DeleteCategory(int id)
        {
            var values = context.Categories.Find(id);
            context.Categories.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();

        } 
        
        [HttpPost]
        public ActionResult AddCategory(Category model)
        {
            context.Categories.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = context.Categories.Find(id);
            return View(value);

        }
        [HttpPost]
        public ActionResult UpdateCategory(Category model)
        {
            var value =context.Categories.Find(model.CategoryId);
            value.CategoryName = model.CategoryName;
            value.ImageUrl = model.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}