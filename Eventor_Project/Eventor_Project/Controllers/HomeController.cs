using Eventor_Project.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eventor_Project.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public ActionResult Index()
        {
            return View();
        }

    }
}
