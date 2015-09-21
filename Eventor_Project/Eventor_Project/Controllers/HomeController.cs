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
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private static Logger logger = LogManager.GetCurrentClassLogger();

        [Inject]
        public Models.SqlRepository.IRepository Repository { get; set; }
        public ActionResult Index()
        {
            var user = Repository.ReadUser(17);
            return View(user.Roles.ToList());
        }

    }
}
