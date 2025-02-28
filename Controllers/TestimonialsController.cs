﻿using BooklyProject.Context;
using BooklyProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooklyProject.Controllers
{
    
    public class TestimonialsController : Controller
    {
        BooklyContext context = new BooklyContext();
        public ActionResult Index()
        {
            var values = context.Testimonials.ToList();
            return View(values);
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var values = context.Testimonials.Find(id);
            context.Testimonials.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();

        }

        [HttpPost]
        public ActionResult AddTestimonial(Testimonial model)
        {
            context.Testimonials.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = context.Testimonials.Find(id);
            return View(value);

        }
        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial model)
        {
            var value = context.Testimonials.Find(model.TestimonialId);
            value.Name = model.Name;
            value.Comment = model.Comment;
            value.Review = model.Review;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}