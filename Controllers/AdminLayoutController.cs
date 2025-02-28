using BooklyProject.Context;
using BooklyProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooklyProject.Controllers
{
    
    public class AdminLayoutController : Controller
    {
        // GET: AdminLayout
        BooklyContext context = new BooklyContext();
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult AdminLayoutNavbar() 
        {

            var userName = Session["currentUser"].ToString();

            if (string.IsNullOrEmpty(userName))
            {
               
                return PartialView("Index","Login");  
            }
            ViewBag.nameSurname= context.Admins.Where(x=>x.UserName == userName).Select(x=>x.FirstName +" "+x.LastName).FirstOrDefault();


            ViewBag.imageUrl= context.Admins.Where(x=>x.UserName ==userName).Select(x=>x.ImageUrl).FirstOrDefault();

            return PartialView();
        }
    }
}