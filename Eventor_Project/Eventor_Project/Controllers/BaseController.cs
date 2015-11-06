using System;
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
    }
}
