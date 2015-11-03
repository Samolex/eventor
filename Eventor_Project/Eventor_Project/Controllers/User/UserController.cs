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

        //
        // GET: /User/


        [Authorize]
        public ActionResult Details(int id = -1)
        {
            id = (id > 0) ? id : CurrentUser.UserId;
            Models.User.User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View("Details", user);
        }


        //
        // POST: /User/Create

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Models.User.User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Repository.CreateUser(user);
        //        return RedirectToAction("Index");
        //    }

        //    return View(user);
        //}


        [Authorize]
        public ActionResult Edit()
        {

            var id = CurrentUser.UserId;
            Models.User.User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View("Edit", user);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.User.User user)
        {
            if (ModelState.IsValid)
            {

                Models.User.User dbUser = db.Users.Find(user.UserId);
                var a = this.MemberwiseClone();

                Type t = user.GetType();
                foreach (PropertyInfo info in t.GetProperties())
                {
                    if (info.CanWrite)
                    {
                        var value = info.GetValue(user);
                        if (value != null)
                            info.SetValue(dbUser, value, null);
                    }
                }

                //db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Models.User.User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /User/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.User.User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}