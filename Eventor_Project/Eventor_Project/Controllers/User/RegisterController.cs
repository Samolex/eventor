using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eventor_Project.Models;
using Eventor_Project.Models.ViewModels;
using Eventor_Project.Tools;
using System.Drawing.Imaging;
using System.Reflection;
using Ninject;
using Eventor_Project.Auth;


namespace Eventor_Project.Controllers.User 
{
    public class RegisterController : BaseController
    {
        private readonly CurrentContext db = new CurrentContext();

        [HttpGet]
        public ActionResult Index()
        {
            var newUserView = new UserRegisterView();
            return View(newUserView);
        }

        [HttpPost]
        public ActionResult Index(UserRegisterView userView)
        {
            if (userView.Captcha != (string)Session[CaptchaImage.CaptchaValueKey])
            {
                ModelState.AddModelError("Captcha", "Текст с картинки введен неверно");
            }
            var anyUser = Repository.Users.Any(p => string.Compare(p.Email, userView.Email) == 0);
            if (anyUser)
            {
                ModelState.AddModelError("Email", "Пользователь с таким email уже зарегистрирован");
            }
            if (ModelState.IsValid)
            {
                var user = (Models.User.User)ModelMapper.Map(userView, typeof(UserRegisterView), typeof(Models.User.User));
                Repository.CreateUser(user);
                return RedirectToAction("Index", "Login");
            }
            return View(userView);
        }
    }
}