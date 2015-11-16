using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Eventor_Project.Models.ProjectModel;
using Newtonsoft.Json;
using Ninject.Infrastructure.Language;
using Eventor_Project.Models.ViewModels;
using Eventor_Project.Models.ProjectModel.Relations;

namespace Eventor_Project.Controllers
{
    public class ProjectsController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            var projectsViewModel = Repository.Projects.ToList()
                .Select(m=>(ProjectCardViewModel)ModelMapper.Map(m, typeof(Project), typeof(ProjectCardViewModel))).ToList();
            ViewBag.Categories = Repository.Categories.ToList();
            return View(projectsViewModel);
        }

        [HttpPost]
        public ActionResult Index(IEnumerable<Project> projects)
        {
            projects = projects ?? Repository.Projects;
            var projectsViewModel = projects.ToList()
                .Select(m => (ProjectCardViewModel)ModelMapper.Map(m, typeof(Project), typeof(ProjectCardViewModel))).ToList();
            ViewBag.Categories = Repository.Categories.ToList();
            return View(projectsViewModel);
        }

        [HttpGet]
        public ActionResult Project(int projectId)
        {
            var project = Repository.ReadProject(projectId);
            if (project == null)
            {
                return HttpNotFound();
            }
            var projectView = (ProjectCardViewModel)ModelMapper.Map(project, typeof(Project), typeof(ProjectCardViewModel));
            var customList = new SelectList(Repository.Customers.Where(m => m.ProjectId == projectId), "customerId", "Role");
            ViewBag.customerId =customList;
            ViewBag.organizerId = new SelectList(Repository.Organisers.Where(m => m.ProjectId == projectId), "organizerId", "Name");
            return View(projectView);
        }

        [HttpPost,Authorize]
        public ActionResult Project(int projectId, int? customerId, int? organizerId)
        {
            var project = Repository.ReadProject(projectId);
            if (customerId != null && customerId != 0)
            {
                var customer = project.Customers.First(m => m.CustomerId == customerId);
                var customers = customer.Customers;
                if (!customers.Contains(CurrentUser))
                {
                    customers.Add(CurrentUser);
                }

                Repository.UpdateCustomer(customer);
            }
            if (organizerId != null)
            {
                var organiser = project.Organisers.First(m => m.OrganizerId == organizerId);
                var organisers = organiser.Users;
                if (!organisers.Contains(CurrentUser))
                {
                    organisers.Add(CurrentUser);
                }
                Repository.UpdateOrganizer(organiser);
            }
            ViewBag.customerId = new SelectList(Repository.Customers.Where(m => m.ProjectId == projectId), "customerId", "Role");
            ViewBag.organizerId = new SelectList(Repository.Organisers.Where(m => m.ProjectId == projectId), "organizerId", "Name");
            var projectView = (ProjectCardViewModel)ModelMapper.Map(project, typeof(Project), typeof(ProjectCardViewModel));
            return View(projectView);
        }

        [HttpGet, Authorize]
        public ActionResult Add()
        {
            var project = new  Project()
            {
                AuthorId = CurrentUser.UserId,
                EventDate = null,
                OrganizationDate = null,
                AddedTime = DateTime.Now,
                ChangeTime = DateTime.Now
            };
            var result = Repository.CreateProject(project);
            return RedirectToAction("Edit", new {projectId=project.ProjectId});
        }

        [HttpGet,Authorize]
        public ActionResult Delete(int projectId)
        {
            var result = Repository.DeleteProject(projectId);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpGet,Authorize]
        public ActionResult Edit(int projectId)
        {
            var project = Repository.ReadProject(projectId);
            if (project == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(Repository.Categories, "CategoryId", "Name", project.CategoryId);
            return View(project);
        }

        [HttpPost,Authorize]
        public ActionResult Edit(Project project)
        {

            ViewBag.CategoryId = new SelectList(Repository.Categories, "CategoryId", "Name", project.CategoryId);
            if (ModelState.IsValid)
            {
                var result = Repository.UpdateProject(project);
            }
            return RedirectToAction("Edit", new { projectId = project.ProjectId });
        }

        #region Inventory_Methods

        [HttpGet, Authorize]
        public JsonResult GetMaterials(int projectId)
        {
            var materials = Repository.ReadProject(projectId)
                .Inventory.Select(m => ModelMapper.Map(m, typeof(Material), typeof(MaterialsJsonModel))).ToEnumerable();
            if (materials == null)
                return Json("");
            return Json(materials, JsonRequestBehavior.AllowGet);
        }
        [HttpPost, Authorize]
        public JsonResult SaveMaterials(List<Material> materials)
        {
            Repository.SaveMaterials(materials);
            return Json("");
        }

        [HttpPost, Authorize]
        public JsonResult SaveMaterialsUser(List<UserMaterial> userMaterials)
        {
            if (userMaterials != null)
            {
                foreach (var item in userMaterials)
                {
                    item.UserId = CurrentUser.UserId;
                    Repository.CreateUserMaterial(item);
                }
            }
            return Json("");
        }
        #endregion
        #region Customers Methods
        [HttpGet, Authorize]
        public JsonResult GetCustomers(int projectId)
        {
            var customers = Repository.ReadProject(projectId)
                .Customers.Select(c => ModelMapper.Map(c, typeof(Customer), typeof(CustomerJsonModel))).ToEnumerable();
            if (customers == null)
                return Json("");
            return Json(customers, JsonRequestBehavior.AllowGet);
        }
        [HttpPost,Authorize]
        public JsonResult SaveCustomers(List<Customer> customers)
        {
            Repository.SaveCustomers(customers);
            return Json("");
        }
        #endregion
        #region Organizers Methods
        [HttpGet, Authorize]
        public JsonResult GetOrganizers(int projectId)
        {
            var organisers = Repository.ReadProject(projectId)
                .Organisers.Select(o => ModelMapper.Map(o, typeof(Organizer), typeof(OrganizerJsonModel))).ToEnumerable();
            if (organisers == null)
                return Json("");
            return Json(organisers, JsonRequestBehavior.AllowGet);
        }

        [HttpPost,Authorize]
        public JsonResult SaveOrganisers(List<Organizer> organisers)
        {
            Repository.SaveOrganisers(organisers);
            return Json("");
        }

        #endregion

        [Authorize]
        public ActionResult MyProjects()
        {
            Func<Project, bool> filter = 
                p => 
                    p.AuthorId == CurrentUser.UserId ||
                    p.Organisers.Any(o => o.Users.Any(u => u.UserId == CurrentUser.UserId)) ||
                    p.Customers.Any(c => c.Customers.Any(u => u.UserId == CurrentUser.UserId));

            return View("Index", CardsByFilter(filter));
        }


        private IEnumerable<ProjectCardViewModel> CardsByFilter(Func<Project, bool> filer)
        {
            return Repository
                .Projects
                .ToList()
                .Where(filer)
                .Select(m => (ProjectCardViewModel) ModelMapper.Map(m, typeof (Project), typeof (ProjectCardViewModel)));
        }

        [HttpGet]
        public ActionResult Search(string title,  int? categoryId)
        {
            Func<Project, bool> titleFilter;
            Func<Project, bool> categoryFilter;

            if (String.IsNullOrEmpty(title))
                titleFilter = p => true;
            else
                titleFilter = p => !String.IsNullOrEmpty(p.Title) && p.Title.ToLower().Contains(title.ToLower());


            if (categoryId == 0 || categoryId == null)
                categoryFilter = p => true;
            else
                categoryFilter = p => p.CategoryId == categoryId;


            Func<Project, bool> searchFilter = p => titleFilter(p) && categoryFilter(p);

            return View("Index", CardsByFilter(searchFilter));
        }

        [HttpGet]

        public ActionResult CardsByCategory(int categoryId)
        {

            Func<Project, bool> categoryFilter = p => p.CategoryId == categoryId;
            return View("Index", CardsByFilter(categoryFilter));
        }
    }
}
