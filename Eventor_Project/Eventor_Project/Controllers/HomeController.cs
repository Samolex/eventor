using Eventor_Project.Models;
using Ninject;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eventor_Project.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {

            var user = Repository.Roles;
            return View(user.ToList());   
	    }
    }
}
