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
    public class UserController : BaseController
    {
        private readonly CurrentContext db = new CurrentContext();

        public ActionResult Captcha()
        {
            Session[CaptchaImage.CaptchaValueKey] = new Random(DateTime.Now.Millisecond).Next(1111, 9999).ToString();
            var ci = new CaptchaImage(Session[CaptchaImage.CaptchaValueKey].ToString(), 211, 50, "Arial");

            // Change the response headers to output a JPEG image.
            this.Response.Clear();
            this.Response.ContentType = "image/jpeg";

            // Write the image to the response stream in JPEG format.
            ci.Image.Save(this.Response.OutputStream, ImageFormat.Jpeg);

            // Dispose of the CAPTCHA image object.
            ci.Dispose();
            return null;
        }

        //
        // GET: /User/

        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        [Authorize]
        public ActionResult AIndex()
        {

            if (CurrentUser.InRoles("admin"))
            {
                //Разрешен просмотр панели управления
                return View(db.Users.ToList());
            }
            return RedirectToNotAdminPage;
            
        }
        //
        // GET: /User/


        [Authorize] 
        public ActionResult Details()
        {
            return View("Info", CurrentUser);
        }

        public ActionResult Info(int id = 0)
        {
            return View(Repository.GetUser(id) ?? CurrentUser);
        }


        [Authorize]
        public ActionResult Edit()
        {
            return View("Edit", CurrentUser);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.User.User user)
        {
            if (ModelState.IsValid)
            {
                Repository.UpdateUser(user);
                return RedirectToAction("Details");
            }
            return View(user);
        }

        //
        // GET: /User/Delete/5
        [Authorize]
        public ActionResult Delete(int id = 0)
        {

            Models.User.User user = Repository.GetUser(id);
            if (user != null)
            {
                if (CurrentUser.InRoles("admin"))
                {
                    //Разрешено удаление
                    return View(user);
                }
                return RedirectToNotAdminPage;
            }
            return RedirectToNotFoundPage;
        }

        //
        // POST: /User/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (CurrentUser.InRoles("admin"))
            {
                Repository.DeleteUser(id);
                return RedirectToAction("Index");
            }
            return RedirectToNotAdminPage;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private IEnumerable<Models.User.User> UsersByFilter(Func<Models.User.User, bool> filer)
        {
            var fios = Repository.Users.ToList().Select(u => u.Fio2.ToLower()).ToList();
            return Repository
                .Users
                .ToList()
                .Where(filer);
        }

        [HttpGet]
        public ActionResult Search(string title)
        {
            title = title ?? "";
            title = title.ToLower();
            Func<Models.User.User, bool> filter = p => p.Nickname.ToLower().Contains(title) || p.Fio2.ToLower().Contains(title);
            return View("Index", UsersByFilter(filter));
        }
    }
}
