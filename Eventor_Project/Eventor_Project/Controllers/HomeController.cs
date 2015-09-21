using System;
using System.Web.Mvc;
using Eventor_Project.Models.ProjectModel;

namespace Eventor_Project.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var project = new Project
            {
                AuthorId = 1,
                CategoryId = 1,
                Description = "",
                Headquarter = "",
                Title = "",
                ShortDescription = "",
                Place = "",
                OrganizationDate = DateTime.Now,
                EventDate = DateTime.Now
            };

            return View();
        }
    }
}