using Eventor_Project.Models;
using Ninject;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

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

            Type t = typeof(Models.User.User);
            var methods = t.GetProperties();
            var roles = Repository.Roles;
            return View(roles.ToList());   
	    }
    }
}
