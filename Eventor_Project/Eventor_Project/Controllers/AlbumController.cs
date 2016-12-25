using Eventor_Project.Auth;
using Eventor_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eventor_Project.Models.User;
using System.IO;
namespace Eventor_Project.Controllers
{
    public class AlbumController : BaseController
    {
        private readonly CurrentContext db = new CurrentContext();

        //
        // GET: /Album/
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Pictures.Where(x => x.OwnerId == CurrentUser.UserId));
        }

        //
        // GET: /Album/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Album/LoadPicture
        [Authorize]
        [HttpPost]
        public ActionResult LoadPicture(Picture pic, HttpPostedFileBase uploadImage)
        {
            if (uploadImage != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                }
                // установка массива байтов
                pic.OwnerId = CurrentUser.UserId;
                pic.Image = imageData;

                Repository.CreatePicture(pic);

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        //
        // POST: /Album/NewPicture

        public ActionResult NewPicture()
        {
            return View();
        }

        //
        // GET: /Album/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Album/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Album/Delete/5

        public ActionResult Delete(int id)
        {
            Repository.DeletePicture(id);
            return RedirectToAction("Index");
        }

        //
        // POST: /Album/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
