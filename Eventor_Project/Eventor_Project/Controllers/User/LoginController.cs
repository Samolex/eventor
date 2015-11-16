using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eventor_Project.Controllers.User
{
    public class LoginController : Controllers.BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Models.ViewModels.LoginView());
        }

        [HttpPost]
        public ActionResult Index(Models.ViewModels.LoginView loginView)
        {
            if (ModelState.IsValid)
            {
                var user = Auth.Login(loginView.Email, loginView.Password, loginView.IsPersistent);
                if (user != null)
                {
                    return RedirectToAction("Index", "Projects");
                }
                ModelState["Password"].Errors.Add("Неверный логин или пароль!");
            }
            return View(loginView);
        }

        public ActionResult Logout()
        {
            Auth.LogOut();
            return RedirectToAction("Index", "Projects");
        }
    }

}
