using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eventor_Project.Models.ProjectModel;
using Ninject.Infrastructure.Language;

namespace Eventor_Project.Controllers
{
    public class ProjectsController : BaseController
    {
        [HttpGet]
        public ActionResult Index(int? category, string filter = "")
        {
            var projects = Repository.Projects.ToEnumerable();
            if (filter == "categories" && category!=null)
            {
                projects = projects.Where(project => project.CategoryId == category);
            }
            return View(projects);
        }
        [HttpGet]
        public ActionResult Project(int author_id, int project_id)
        {
            var project = Repository.Projects
                .FirstOrDefault(p => p.AuthorId == author_id && p.ProjectId == project_id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }
        [HttpGet]
        public ActionResult Add()
        {
             var project = new  Project()
             {
                 //TODO: Add current user
                 AuthorId = 1,
                 Title = "10101010101",
                 ShortDescription = "10",
                 Description = "10",
                 Headquarter = "10",
                 Place = "10",
                 CategoryId = 1,
                 OrganizationDate = DateTime.MinValue.AddYears(1970),
                 EventDate = DateTime.MinValue.AddYears(1970),
                 AddedTime = DateTime.Now,
                 ChangeTime = DateTime.Now
             };
            Db.Projects.Add(project);
            Db.SaveChanges();
            return Redirect(string.Format("Edit?project_id={0}", project.ProjectId));
        }

        [HttpGet]
        public ActionResult Delete(int project_id)
        {
            var project = Db.Projects.FirstOrDefault(p => p.ProjectId == project_id);
            if (project == null)
                return HttpNotFound();
            Db.Projects.Remove(project);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int project_id)
        {
            var project = Repository.Projects
                .FirstOrDefault(p =>p.ProjectId == project_id);
            if (project == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(Repository.Categories, "CategoryId", "Name", project.CategoryId);
            return View(project);
        }

        [HttpPost]
        public EmptyResult AddMaterial(Material material)
        {
            if (ModelState.IsValid)
            {
                Db.Materials.Add(material);
                Db.SaveChanges();
            }
            return new EmptyResult();
        }

        [HttpGet]
        public EmptyResult DeleteMaterial(int material_id)
        {
            Db.Materials.Remove(Db.Materials.Find(material_id));
            //TODO: Delete UserMaterial witn Id == materialId
            Db.SaveChanges();
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult Edit(Project project)
        {
            if (ModelState.IsValid)
            {
                project.ChangeTime = DateTime.Now;
                Db.Entry(project).State = EntityState.Modified;
                Db.SaveChanges();
            }
            ViewBag.CategoryId = new SelectList(Repository.Categories, "CategoryId", "Name", project.CategoryId);
            return View(project);
        }

        protected override void Dispose(bool disposing)
        {
            Db.Dispose();
            base.Dispose(disposing);
        }
    }
}
