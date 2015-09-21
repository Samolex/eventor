using System.Web.Mvc;

namespace Eventor_Project.Controllers
{
    public class ProjectsController : BaseController
    {
        //
        // GET: /Projects/

        public ActionResult Index()
        {
            return View();
        }
    }
}