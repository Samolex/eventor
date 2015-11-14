using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Eventor_Project.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return View();

        }

        public ActionResult NotFoundPage()
        {
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            return View();

        }

        public ActionResult NotAdminPage()
        {
            Response.StatusCode = (int)HttpStatusCode.Forbidden;
            return View();

        }
    }
}
