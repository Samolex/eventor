using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Eventor_Project.Models;
using Eventor_Project.Models.SqlRepository;
using Ninject;
using NLog;
using Eventor_Project.Mappers;
using System.Security.Principal;
using Eventor_Project.Auth;

namespace Eventor_Project.Controllers
{
    public class BaseController : Controller
    {
        protected static Logger Logger = LogManager.GetCurrentClassLogger();

        [Inject]
        public IAuthentication Auth { get; set; }

        public Models.User.User CurrentUser
        {
            get
            {
                return ((IUserProvider)Auth.CurrentUser.Identity).User;
            }
        }
        [Inject]
        public IRepository Repository { get; set; }
        [Inject]
        public IMapper ModelMapper { get; set; }
        [Inject]
        public CurrentContext Db { get; set; }

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            ViewBag.CurrentUser = CurrentUser;
            base.OnResultExecuting(filterContext);
        }


        protected static string ErrorPage = "~/Error";
        protected static string NotFoundPage = "~/NotFoundPage";

        protected static string NotAdminPage = "~/NotAdminPage";

        public RedirectResult RedirectToNotFoundPage
        {
            get
            {
                return Redirect(NotFoundPage);
            }
        }

        public RedirectResult RedirectToNotAdminPage
        {
            get
            {
                return Redirect(NotAdminPage);
            }
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);

            filterContext.Result = Redirect(ErrorPage);
        }
    }
}
