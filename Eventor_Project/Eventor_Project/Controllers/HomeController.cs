using Eventor_Project.Models;
using Ninject;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Eventor_Project.Models.ProjectModel;

namespace Eventor_Project.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var cookie = new HttpCookie("test_cookie")
            {
                Value = DateTime.Now.ToString("dd.MM.yyyy"),
                Expires = DateTime.Now.AddMinutes(10),
            };
            Response.SetCookie(cookie);
            var cookie2 = Request.Cookies["test_cookie"];
            Type t = typeof(Models.User.User);
            var methods = t.GetProperties();
            var roles = Repository.Roles;
            return View(roles.ToList());   
	    }

        public ActionResult UserLogin()
        {
            return View(CurrentUser);
        }
    }
}
