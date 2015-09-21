using System.Web.Mvc;
using Eventor_Project.Models.SqlRepository;
using Ninject;
using NLog;

namespace Eventor_Project.Controllers
{
    public class BaseController : Controller
    {
        protected static Logger Logger = LogManager.GetCurrentClassLogger();

        [Inject]
        public IRepository Repository { get; set; }
    }
}