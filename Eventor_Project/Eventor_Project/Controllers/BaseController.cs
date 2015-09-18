using System.Web.Mvc;
using Eventor_Project.Models.SqlRepository;
using Ninject;
using NLog;

namespace Eventor_Project.Controllers
{
    public class BaseController : Controller
    {
        [Inject]
        public IRepository Repository { get; set; }

        protected static Logger Logger = LogManager.GetCurrentClassLogger();

    }
}
