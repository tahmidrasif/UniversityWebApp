﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UniversityWebApp.Areas.Admin.Models;
using UniversityWebApp.Repository;

namespace UniversityWebApp.Controllers
{
    public class HomeController : Controller
    {
        private MyDbContext db=new MyDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(User aUser)
        {
            var user = db.Users.FirstOrDefault(x => x.UserName == aUser.UserName && x.Password == aUser.Password);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(Convert.ToString(user.UserId), false);
                Session["User"] = user;
                if (user.UserType == "Admin")
                {
                    return RedirectToAction("Index", "User", new { Area = "Admin" });
                }
                if (user.UserType == "Student")
                {
                   // return RedirectToAction("Index", "User", new { Area = "Admin" });
                }
        
            }
            return RedirectToAction("Index");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session["User"] = null;
            return RedirectToAction("Index");

        }

    }
}